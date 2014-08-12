using ATU.Web.Domain.Abstract;
using System;
using System.Web;

namespace ATU.Web.Domain.Concrete
{
    public class InMemoryCache : ICacheService
    {
        public T Get<T>(string cacheId, Func<T> getItemCallback) where T : class
        {
            var item = HttpRuntime.Cache.Get(cacheId) as T;
            if (item == null)
            {
                item = getItemCallback();
                HttpContext.Current.Cache.Insert(cacheId, item);
            }
            return item;
        }

        public void Clear()
        {
            var items = HttpContext.Current.Cache.GetEnumerator();
            while (items.MoveNext())
            {
                HttpContext.Current.Cache.Remove(items.Key.ToString());
            }
        }

        public void ClearKey(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }
    }
}
