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
        private AssetReferenceGameObject productViewPrefabReference = new("ProductView");

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

            BindShop();

            BindSettings();

            BindWindowFsm();
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


        private void BindSettings()
        {
            Container
              .BindInterfacesAndSelfTo<SettingsModel>()
              .AsSingle()
              .NonLazy();

            Container
                .BindInterfacesAndSelfTo<SettingsViewModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindShop()
        {               
            Container.BindInterfacesAndSelfTo<ProductViewFactory>()
                .AsSingle()
                .WithArguments(productViewPrefabReference)
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
