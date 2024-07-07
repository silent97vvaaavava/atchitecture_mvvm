//using Assets.Training.Domain.Products;
//using UnityEngine;
//using Zenject;

//namespace Training.Domain.Products
//{
//    public interface IBaseProductViewFactory<out T> : IFactory<Transform, T> where T : CurrencyProductView { }

//    public class BaseProductViewFactory<T> : IBaseProductViewFactory<T> where T : CurrencyProductView
//    {
//        private readonly DiContainer _container;
//        private readonly BaseProduct _productViewFactoryPrefab;

//        protected BaseProductViewFactory(DiContainer container, BaseProduct baseProductFactoryPrefab)
//        {
//            _container = container;
//            _productViewFactoryPrefab = baseProductFactoryPrefab;
//        }

//        public T Create(Transform param)
//        {
//            var product = _container.InstantiatePrefabForComponent<T>(_productViewFactoryPrefab, param);
//            //product.gameObject.SetActive(false);
//            return product;
//        }
//    }
//}