namespace Core.Domain.Factories
{
    public interface ICustomFactory<in T>  
    {
        TViewModel Create<TViewModel>()
            where TViewModel : class, T;
    }
}