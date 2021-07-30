using Xamarin.Essentials;

namespace imout.Core.Utils
{
    public class StorageWrapper
    {
        public string Get(string key, string defaultValue)
        {
            return Preferences.Get(key, defaultValue);
        }

        public void Set(string key, string value)
        {
            Preferences.Set(key, value);
        }
    }
}
