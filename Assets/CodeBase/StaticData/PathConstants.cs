using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBase.StaticData
{
    public class PathConstants
    {
        public const string USERS = "users";
        public const string CURRENCY = "users_currency";
        public const string DATA = "users_data";

        private static readonly List<string> Keys = new List<string>()
        {
            USERS,
            CURRENCY,
            DATA,
        };

        private const string Tag = "Dto";

        public static string GetKeyPath(Type type)
        {
            string keyPath = String.Empty;

            
            string key = type
                .Name
                .Replace(Tag, "");
            keyPath = Keys.FirstOrDefault(keyInList => keyInList.Contains(key, StringComparison.OrdinalIgnoreCase));
            
            return keyPath;
        }
    }
}