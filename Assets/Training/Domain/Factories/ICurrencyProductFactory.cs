using Core.UI.Popup;
using Zenject;

namespace Assets.Training.Domain.Factories
{
    public interface ICurrencyProductFactory : IBaseProductFactory<Product> { }

    public class CurrencyProductFactory : BaseProductFactory<Product>, ICurrencyProductFactory
    {
        protected CurrencyProductFactory(DiContainer container, Product baseProductFactoryPrefab)
            : base(container, baseProductFactoryPrefab)
        {

        }
    }
}