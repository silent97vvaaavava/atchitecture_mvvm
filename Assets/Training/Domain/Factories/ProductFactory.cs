using Assets.Training;
using Zenject;

namespace Training.Domain.Factories
{
    public class ProductFactory : IProductFactory
    {
        private readonly DiContainer _diContainer;

        public ProductFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public TProduct Create<TProduct>() where TProduct : class, IProduct
        {
            return _diContainer.Instantiate<TProduct>();
        }
    }

    public interface IProductFactory
    {

    }
}