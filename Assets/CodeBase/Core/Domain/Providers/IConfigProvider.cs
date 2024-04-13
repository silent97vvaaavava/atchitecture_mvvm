namespace Core.Domain.Providers
{
    public interface IConfigProvider<in TConfig> : IProviderGet<TConfig>
    {
        void OnSet(TConfig value);
    }
}