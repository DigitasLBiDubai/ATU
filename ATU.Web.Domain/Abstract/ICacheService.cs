using System;

namespace ATU.Web.Domain.Abstract
{
    public interface ICacheService
    {
        T Get<T>(string cacheId, Func<T> getItemCallback) where T : class;
        void Clear();
        void ClearKey(string key);
    }
}