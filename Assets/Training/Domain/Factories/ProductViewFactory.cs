using Cysharp.Threading.Tasks;
using Training.Domain.Products;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Training.Domain.Factories
{
    public class ProductViewFactory : IProductViewFactory   
    {
        private readonly DiContainer _diContainer;
        private readonly AssetReferenceGameObject _productViewAssetReference;    

        public ProductViewFactory(DiContainer diContainer, AssetReferenceGameObject productPrefab)
        {
            _diContainer = diContainer;
            _productViewAssetReference = productPrefab;
        }

        public async UniTask<ProductView> Create(Transform parent)
        {
            //var prefab = await _productViewAssetReference.LoadAssetAsync().Task; Эстетика Adressables(оно не работает, счётчик ссылок встроен в штуку ниже)
            //AsyncOperationHandle<GameObject> handle = _productViewAssetReference.LoadAssetAsync(); Эстетика 2.0
            AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(_productViewAssetReference);

            GameObject prefab = await handle.Task;

            Addressables.Release(handle); 

            return _diContainer.InstantiatePrefabForComponent<ProductView>(prefab, parent);
        }
    }

    public interface IProductViewFactory
    {
        UniTask<ProductView> Create(Transform parent);
    }
}
