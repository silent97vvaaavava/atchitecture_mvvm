using Core.MVVM.WindowFsm;
using Cysharp.Threading.Tasks;
using Training.Domain.Factories;
using Training.Domain.Products;
using Training.Domain.Providers;
using Training.MVVM.Model;
using Training.MVVM.View;
using Training.MVVM.ViewModel;
using Training.MVVM.WindowFsm;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Training.Installers
{
    public class MainMenuSceneInstaller : MonoInstaller
    {
        [Inject] private WindowFsmProvider _fsmProvider;
        public AssetReference productPrefabReference;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<MainMenuModel>()
                .AsSingle()
                .NonLazy();
            Container
                .BindInterfacesAndSelfTo<MainMenuViewModel>()
                .AsSingle()
                .NonLazy();

            Container
               .BindInterfacesAndSelfTo<SaveModel>()
               .AsSingle()
               .NonLazy();

            Container
                .BindInterfacesAndSelfTo<CurrencyModel>()
                .AsSingle()
                .NonLazy();

            BindShop().Forget();

            BindSettings();

            BindWindowFsm();
        }

        private void BindSettings()
        {
            Container
                .BindInterfacesAndSelfTo<SettingsViewModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindWindowFsm()
        {
            var localWindowFsm = Container.Instantiate<WindowFsm>();

            localWindowFsm.fsmNumber = 1;

            localWindowFsm.Set<MainMenuView>();
            localWindowFsm.Set<SettingsView>();
            localWindowFsm.Set<ShopView>();

            Container
                .Bind<IWindowFsm>()
                .FromInstance(localWindowFsm)
                .AsSingle()
                .NonLazy();

            _fsmProvider.Set(localWindowFsm);
        }

        private async UniTaskVoid BindShop()
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(productPrefabReference);
            var productPrefab = await handle.Task;
            var productViewComponent = productPrefab.GetComponent<ProductView>();

            Container.BindInterfacesAndSelfTo<ProductViewFactory>()
                .AsSingle()
                .WithArguments(productViewComponent)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<ShopModel>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<ShopViewModel>()
                .AsSingle()
                .NonLazy();
        }
    }
}
