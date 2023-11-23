namespace CodeBase.Infrastructure.Providers
{
    public interface IConfigProvider<in TConfig> : IProvider
    {
        void OnSet(TConfig value);
    }
}