using Xamarin.Essentials;

namespace imout.Core.Utils.Storage
{
    public class StorageWrapper: IStorageWrapper
    {
        private string storageKey = "im-out-storage";

        public string Get()
        {
            return Preferences.Get(storageKey, "[]");
        }

        public void Set(string value)
        {
            Preferences.Set(storageKey, value);
        }
    }
}
