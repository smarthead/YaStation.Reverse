using System;
using System.Collections;
using System.Net;
using System.Reflection;

namespace YaStation.Reverse.Core.Common.CookieContainer
{
    public static class CookieContainerExtensions
    {
        public static CookieCollection GetCookies(this System.Net.CookieContainer container)
        {
            var cookieCollection = new CookieCollection();

            var hashTable = container
                .GetType()
                .InvokeMember("m_domainTable",
                    BindingFlags.NonPublic |
                    BindingFlags.GetField |
                    BindingFlags.Instance,
                    null,
                    container,
                Array.Empty<object>()) as Hashtable;

            if (hashTable == null)
                return null;
            
            foreach (var key in hashTable.Keys)
            {
                var tableName = key
                    .ToString();

                if (!hashTable.ContainsKey(tableName!))
                    continue;
                
                var values = (SortedList) hashTable[tableName]!
                    .GetType()
                    .InvokeMember("m_list",
                        BindingFlags.NonPublic |
                        BindingFlags.GetField |
                        BindingFlags.Instance,
                        null,
                        hashTable[tableName],
                    Array.Empty<object>());

                if (values == null)
                    return null;
                
                foreach (var listKey in values.Keys)
                {
                    var url = $"https://{tableName.TrimStart('.')}{listKey}";
                    cookieCollection.Add(container.GetCookies(new Uri(url)));
                }
            }

            return cookieCollection;
        }
    }
}