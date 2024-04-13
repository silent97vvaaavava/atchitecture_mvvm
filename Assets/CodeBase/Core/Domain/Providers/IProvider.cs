namespace Core.Domain.Providers
{
    public interface IProviderGet<in TObject>
    {
        TValue Get<TValue>() where TValue : class, TObject;
    }
    
    public interface IProviderSet<in TObject>
    {
        void Set<TValue>() where TValue : class, TObject;
    }
}