using YG;

public class YandexCloudSaveLoader : JsonSaveLoader
{
    public new void LoadData()
    {
        YandexGame.LoadCloud();
    }

    public new void SaveData()
    {
        base.SaveData();
        YandexGame.SaveCloud();
    }
}
