using Training.Domain.Products;
using UnityEngine;
using Zenject;

namespace Training.Domain.Factories
{
    public class ProductViewFactory : IProductViewFactory
    {
        private readonly DiContainer _diContainer;
        private readonly ProductView _productPrefab;

        public ProductViewFactory(DiContainer diContainer, ProductView productPrefab)
        {
            _diContainer = diContainer;
            _productPrefab = productPrefab;
        }

        public ProductView Create(Transform parent)
        {
            return _diContainer.InstantiatePrefabForComponent<ProductView>(_productPrefab, parent);
        }
    }

    public interface IProductViewFactory
    {
        ProductView Create(Transform parent);
    }
}
