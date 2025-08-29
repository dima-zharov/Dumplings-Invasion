mergeInto(LibraryManager.library,
{
	InitGame_js: function ()
	{
		InitGame();
	},

	FullAdShow: function ()
	{
		ysdk.adv.showFullscreenAdv({
			callbacks: {
				onOpen: () => {
					myGameInstance.SendMessage("PauseManager", "Pause"); 
				},
				onClose: (wasShown) => {
					myGameInstance.SendMessage("PauseManager", "Resume"); 
				},
				onError: (err) => {
					console.error("FullAd error:", err);
					myGameInstance.SendMessage("PauseManager", "Resume"); 
				}
			}
		});
	},

    RewardedShow: function (id)
	{
		ysdk.adv.showRewardedVideo({
			callbacks: {
				onOpen: () => {
					myGameInstance.SendMessage("PauseManager", "Pause");
				},
				onRewarded: () => {
					RewardedShow(id); 
				},
				onClose: () => {
					myGameInstance.SendMessage("PauseManager", "Resume");
				},
				onError: () => {
					myGameInstance.SendMessage("PauseManager", "Resume");
				}
			}
		});
	},

	ReviewInternal: function()
	{
		Review();
	},
	
	PromptShowInternal: function()
	{
		PromptShow();
	},
	
	StickyAdActivityInternal: function(show)
	{
		StickyAdActivity(show);
	},
	
	GetURLFromPage: function () {
        var returnStr = (window.location != window.parent.location) ? document.referrer : document.location.href;
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
		
        return buffer;
    },
	
	OpenURL: function (url) {
		window.open(UTF8ToString(url), "_blank");
	
		//var a = document.createElement("a");
		//a.setAttribute("href", UTF8ToString(url));
		//a.setAttribute("target", "_blank");
		//a.click();
	},
	
	GameplayStart_js: function () {
		if (ysdk !== null && ysdk.features !== undefined && ysdk.features.GameplayAPI !== undefined) {
			ysdk.features.GameplayAPI.start();
		}
		else {
			if (ysdk == null) console.error('Gameplay start rejected. The SDK is not initialized!');
			else console.error('Gameplay start undefined!');
		}
	},
	
	GameplayStop_js: function () {
		if (ysdk !== null && ysdk.features !== undefined && ysdk.features.GameplayAPI !== undefined) {
			ysdk.features.GameplayAPI.stop();
		}
		else {
			if (ysdk == null) console.error('Gameplay stop rejected. The SDK is not initialized!');
			else console.error('Gameplay stop undefined!');
		}
	},
	
	ServerTime_js: function() {
        if (ysdk !== null) {
            var serverTime = ysdk.serverTime().toString();
            var lengthBytes = lengthBytesUTF8(serverTime) + 1;
            var stringOnWasmHeap = _malloc(lengthBytes);
            stringToUTF8(serverTime, stringOnWasmHeap, lengthBytes);
            return stringOnWasmHeap;
        }
        return 0;
    },
	
	SetFullscreen_js: function (fullscreen) {
		if (ysdk !== null) {
			if (fullscreen) {
				if (ysdk.screen.fullscreen.status != 'on')
					ysdk.screen.fullscreen.request();
			}
			else if (ysdk.screen.fullscreen.status != 'off')
				ysdk.screen.fullscreen.exit();
		}
	},
	
	IsFullscreen_js: function () {
		if (ysdk !== null) {
			if (ysdk.screen.fullscreen.status == 'on')
				return true;
			else
				return false;
		}
		return false;
	},


MakePurchase: function() {
    payments.purchase({ id: 'cat' }).then(function(purchase) {

        try { myGameInstance.SendMessage("UnlockTypes", "BuyPlayer"); } catch (e) {}

        if (typeof ysdk !== 'undefined' && ysdk.getPlayer) {
            ysdk.getPlayer({ signed: true }).then(function(player) {
                player.getData().then(function(data) {
                    data = data || {};
                    var unlocked = data.unlockedSkins || {};
                    unlocked.cat = true;           
                    data.unlockedSkins = unlocked;
                    player.setData(data, true).catch(function(err) {
                        console.warn('Cloud save failed:', err);
                    });
                }).catch(function(err) {
                    console.warn('player.getData failed:', err);
                });
            }).catch(function(err) {
                console.warn('ysdk.getPlayer failed:', err);
            });
        }

    }).catch(function(err) {
        // покупка не удалась / отменена
        myGameInstance.SendMessage("UnlockInfoPanel", "ShowErrorMessage");
    });
},


	WatchAddGetPlayerExtern : function(){
		ysdk.adv.showRewardedVideo({
			callbacks:{
			    onOpen: () => {
	                console.log("Реклама открыта");
	            },
				onRewarded: () => {
					myGameInstance.SendMessage("UnlockTypes", "WatchAddGetPlayer");
				},
				onClose: () => {
		             console.log("Реклама закрыта");
		                
		        },
		        onError: () => {
		             console.log("Невозможно воспроизвести рекламу");
		        }
			}
		})
	},

	CheckAttemptsExtern : function(){
	let rewarded = false;
	
	ysdk.adv.showRewardedVideo({
			callbacks:{
				onRewarded: () => {
					rewarded = true;
					myGameInstance.SendMessage("LoadCanvas", "WatchAdd");
					myGameInstance.SendMessage("LoadCanvas", "SpendAttemp");
				},
	            onClose: () => {
	                if (!rewarded) {
	                    myGameInstance.SendMessage("LoadCanvas", "FinishGame");
	                }
	            },
	            onError: () => {
	                myGameInstance.SendMessage("LoadCanvas", "FinishGame");
	            }
			}
		})
	},

});