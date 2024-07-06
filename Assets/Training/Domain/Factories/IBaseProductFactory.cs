using Assets.Training.Domain.Products;
using UnityEngine;
using Zenject;

namespace Core.UI.Popup
{
    public interface IBaseProductFactory<out T> : IFactory<Transform, T> where T : BaseProduct { }

    public class BaseProductFactory<T> : IBaseProductFactory<T> where T : BaseProduct
    {
        private readonly DiContainer _container;
        private readonly BaseProduct _baseProductFactoryPrefab;

        protected BaseProductFactory(DiContainer container, BaseProduct baseProductFactoryPrefab)
        {
            _container = container;
            _baseProductFactoryPrefab = baseProductFactoryPrefab;
        }

        public T Create(Transform param)
        {
            var product = _container.InstantiatePrefabForComponent<T>(_baseProductFactoryPrefab, param);
            //product.gameObject.SetActive(false);
            return product;
        }
    }
}