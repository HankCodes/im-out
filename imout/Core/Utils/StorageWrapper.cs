using Xamarin.Essentials;

namespace imout.Core.Utils
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
