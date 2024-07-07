using Core.MVVM.WindowFsm;
using Training.Domain.Factories;
using Training.Domain.Products;
using Training.Domain.Providers;
using Training.MVVM.Model;
using Training.MVVM.View;
using Training.MVVM.ViewModel;
using Training.MVVM.WindowFsm;
using UnityEngine;
using Zenject;

namespace Training.Installers
{
    public class MainMenuSceneInstaller : MonoInstaller
    {
        [Inject] private WindowFsmProvider _fsmProvider;
        [SerializeField] private ProductView _productPrefab;

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

            //Container
            //    .BindInterfacesAndSelfTo<SettingsModel>()
            //    .AsSingle()
            //    .NonLazy();
            Container
                .BindInterfacesAndSelfTo<SettingsViewModel>()
                .AsSingle()
                .NonLazy();

            //Container
            //    .BindInterfacesAndSelfTo<CurrencyModel>()
            //    .AsSingle()
            //    .NonLazy();

            BindShop();
           
            BindWindowFsm();
        }

        private void BindWindowFsm()
        {
            var localWindowFsm = Container.Instantiate<WindowFsm>();

            localWindowFsm.fsmNumber = 1;

            //Not good
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

        private void BindShop()
        {
            Container
                .BindInterfacesAndSelfTo<ProductViewFactory>()
                .AsSingle()
                .WithArguments(_productPrefab)
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

        //private void BindProviders()
        //{
        //    Container
        //        .BindInterfacesAndSelfTo<ViewModelFactory>()
        //        .FromNew()
        //        .AsSingle()
        //    .NonLazy();

        //    var provider = Container
        //        .Instantiate<ViewModelProvider>();
        //    Container
        //        .BindInterfacesAndSelfTo<ViewModelProvider>()
        //        .FromInstance(provider)
        //        .AsSingle()
        //        .NonLazy();

        //    provider.Set<MainMenuViewModel>();
        //}
    }
}