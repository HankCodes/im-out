using System;
using Xamarin.Essentials;

namespace imout.Core.Utils
{
    public class StorageWrapper
    {
        public string Get(string key)
        {
            return Preferences.Get(key, "");
        }

        public void Set(string key, string value)
        {
            Preferences.Set(key, value);
        }
    }
}
