mergeInto(LibraryManager.library, {
  SaveExtern: function(ptr) {
    // вызывается из Unity: ptr — указатель на UTF8 строку
    var jsonString = UTF8ToString(ptr || 0);
    YGBridge_initIfNeeded();
    YGBridge_Save(jsonString);
  },

  LoadExtern: function() {
    YGBridge_initIfNeeded();
    YGBridge_Load();
  },

  FlushPendingDataToUnity: function() {
    YGBridge_initIfNeeded();
    YGBridge_Flush();
  }
});

/* --- Вспомогательные функции --- */
/* ВАЖНО: вложенный код НЕ должен исполняться при загрузке файла в Node.
   Все обращения к window / myGameInstance / player делаются внутри функций. */

function YGBridge_initIfNeeded() {
  if (typeof YGBridge_internal !== 'undefined' && YGBridge_internal._initialized) return;
  // создаём пространство имён
  YGBridge_internal = {
    _initialized: true,
    _pendingQueue: [],
    _sending: false,
    _backupKey: 'yg_backup'
  };

  // listeners и периодические flush только в браузере
  if (typeof window !== 'undefined' && typeof document !== 'undefined') {
    // при уходе со страницы — сохранить backup
    try {
      window.addEventListener('pagehide', function(){
        try {
          var q = YGBridge_internal._pendingQueue;
          if (q && q.length) {
            var last = q[q.length - 1];
            if (last && last.json) localStorage.setItem(YGBridge_internal._backupKey, last.json);
          }
        } catch(e){}
      });
    } catch(e) {}

    // при возврате в видимый таб — попытаться отправить
    try {
      document.addEventListener('visibilitychange', function(){
        if (document.visibilityState === 'visible') {
          YGBridge_Flush();
        }
      });
    } catch(e) {}

    // периодический фейлсейф
    try {
      setInterval(function(){ try { YGBridge_Flush(); } catch(e){} }, 5000);
    } catch(e) {}
  }
}

function YGBridge_Save(jsonString) {
  // try parse to object before sending to player
  var dataObj = {};
  try {
    dataObj = JSON.parse(jsonString || "{}");
  } catch (e) {
    // некорректный JSON — сохраняем в localStorage как backup
    try { if (typeof localStorage !== 'undefined') localStorage.setItem(YGBridge_internal._backupKey, jsonString); } catch(err){}
    console && console.error && console.error("YGBridge_Save: invalid JSON", e);
    return;
  }

  // локальная страховка
  try { if (typeof localStorage !== 'undefined') localStorage.setItem(YGBridge_internal._backupKey, jsonString); } catch(e){}

  // попытаться сохранить через Yandex SDK
  safeEnsurePlayer().then(function(player){
    try {
      player.setData(dataObj).then(function(){
        console && console.log && console.log("YGBridge_Save: player.setData success");
      }).catch(function(err){
        console && console.error && console.error("YGBridge_Save: player.setData failed", err);
      });
    } catch(err){
      console && console.error && console.error("YGBridge_Save: exception calling setData", err);
    }
  }).catch(function(){
    // player не доступен — полагаемся на backup
    console && console.warn && console.warn("YGBridge_Save: player not ready, saved to backup only");
  });
}

function YGBridge_Load() {
  safeEnsurePlayer().then(function(player){
    try {
      player.getData().then(function(_date){
        try {
          var myJSON = JSON.stringify(_date || {});
          YGBridge_queueDeliver(myJSON);
        } catch(e){
          console && console.error && console.error("YGBridge_Load: stringify error", e, _date);
          YGBridge_deliverFallback();
        }
      }).catch(function(err){
        console && console.error && console.error("YGBridge_Load: player.getData failed", err);
        YGBridge_deliverFallback();
      });
    } catch(e){
      console && console.error && console.error("YGBridge_Load: exception", e);
      YGBridge_deliverFallback();
    }
  }).catch(function(){
    console && console.warn && console.warn("YGBridge_Load: player not ready, using fallback");
    YGBridge_deliverFallback();
  });
}

function YGBridge_Flush() {
  YGBridge_initIfNeeded();
  YGBridge_flushQueue();
}

/* --- Queue / delivery helpers --- */

function YGBridge_deliverFallback() {
  try {
    var backup = (typeof localStorage !== 'undefined') ? localStorage.getItem(YGBridge_internal._backupKey) : null;
    if (!backup) backup = '{}';
    YGBridge_queueDeliver(backup);
  } catch(e) {
    console && console.error && console.error("YGBridge_deliverFallback error", e);
    YGBridge_queueDeliver('{}');
  }
}

function YGBridge_queueDeliver(json) {
  YGBridge_initIfNeeded();
  YGBridge_internal._pendingQueue.push({ json: json, attempts: 0 });
  YGBridge_flushQueue();
}

function YGBridge_flushQueue() {
  if (!YGBridge_internal || YGBridge_internal._sending) return;
  YGBridge_internal._sending = true;
  var q = YGBridge_internal._pendingQueue;
  if (!q || q.length === 0) { YGBridge_internal._sending = false; return; }

  (function sendNext(){
    if (!YGBridge_internal._pendingQueue || YGBridge_internal._pendingQueue.length === 0) {
      YGBridge_internal._sending = false;
      return;
    }
    var item = YGBridge_internal._pendingQueue[0];

    if (typeof myGameInstance !== 'undefined' && myGameInstance && typeof myGameInstance.SendMessage === 'function') {
      try {
        myGameInstance.SendMessage('Data', 'SetData', item.json);
        // success -> remove item
        YGBridge_internal._pendingQueue.shift();
        setTimeout(sendNext, 100);
      } catch (e) {
        console && console.error && console.error("YGBridge_flushQueue: SendMessage failed", e);
        item.attempts = (item.attempts || 0) + 1;
        if (item.attempts >= 6) {
          console && console.warn && console.warn("YGBridge_flushQueue: dropping item after retries");
          try { if (typeof localStorage !== 'undefined') localStorage.setItem(YGBridge_internal._backupKey, item.json); } catch(err){}
          YGBridge_internal._pendingQueue.shift();
          setTimeout(sendNext, 100);
        } else {
          var delay = Math.min(2000, 200 * Math.pow(2, item.attempts));
          setTimeout(sendNext, delay);
        }
      }
    } else {
      // myGameInstance не готов — повторим позже
      setTimeout(function(){
        YGBridge_internal._sending = false;
        YGBridge_flushQueue();
      }, 300);
    }
  })();
}

/* --- safeEnsurePlayer: ждёт появления глобального player (Yandex SDK) --- */
function safeEnsurePlayer(timeoutMs) {
  timeoutMs = timeoutMs || 7000;
  return new Promise(function(resolve, reject){
    try {
      if (typeof player !== 'undefined' && player && typeof player.getData === 'function') {
        resolve(player); return;
      }
      // polling (только в браузере)
      if (typeof window === 'undefined') {
        reject(new Error("safeEnsurePlayer: not running in browser"));
        return;
      }
      var waited = 0;
      var interval = 200;
      var max = Math.ceil(timeoutMs / interval);
      var tries = 0;
      var t = setInterval(function(){
        tries++;
        if (typeof player !== 'undefined' && player && typeof player.getData === 'function') {
          clearInterval(t);
          resolve(player);
          return;
        }
        if (tries >= max) {
          clearInterval(t);
          reject(new Error("player not found within timeout"));
          return;
        }
      }, interval);
    } catch(e){
      reject(e);
    }
  });
}
