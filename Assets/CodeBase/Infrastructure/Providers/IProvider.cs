namespace CodeBase.Infrastructure.Providers
{
    public interface IProvider<in TObject>
    {
        TValue Get<TValue>() where TValue : class, TObject;
    }
}