namespace imout.Core.Utils.Storage
{
    public interface IStorageWrapper
    {
        string Get();

        void Set(string value);
    }
}
