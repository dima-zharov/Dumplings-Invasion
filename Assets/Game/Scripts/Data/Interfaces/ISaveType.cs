using UnityEngine;

public interface ISaveType : IDataSaveLoader
{
    void SetData<T>(T value);
    bool TryGetData<T>(out T value);
}
