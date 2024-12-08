namespace NetMvc.Cms.Common.Interfaces
{
    public interface ICacheHelper
    {
        object Get(string key);
        void Set(string key, object data, int cacheTime=60);
        bool IsSet(string key);
        void Invalidate(string key);
    }
}
