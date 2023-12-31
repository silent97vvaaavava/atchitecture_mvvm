namespace CodeBase.Services
{
    public class DatabaseTable : ISaveDatabase
    {
        public void Save<TData>(string path, TData data)
        where TData : class
        {
            
        }

        public void SaveAsync()
        {
        }
    }
}