using CodeBase.Domain;

namespace CodeBase.Services
{
    public interface ISaveDatabase
    {
        void Save<TData>(string path, TData data)
            where TData : class;
        void SaveAsync();
    }
}