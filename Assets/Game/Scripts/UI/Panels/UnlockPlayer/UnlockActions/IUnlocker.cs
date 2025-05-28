public interface IUnlocker
{
    int PlayerIndex { get; }  
    string Description {  get; }
    void Unlock();
}
