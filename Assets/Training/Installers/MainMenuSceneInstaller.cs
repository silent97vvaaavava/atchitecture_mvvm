using Core.Domain.Factories;
using Core.Domain.Providers;
using Core.MVVM.WindowFsm;
using Training.Domain.Providers;
using Training.MVVM.Model;
using Training.MVVM.View;
using Training.MVVM.ViewModel;
using Training.MVVM.WindowFsm;
using Zenject;

namespace Training.Installers
{
    public class MainMenuSceneInstaller : MonoInstaller
    {
        [Inject] private WindowFsmProvider _fsmProvider;
        
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

            BindWindowFsm();
        }

        private void BindWindowFsm()
        {
            var localWindowFsm = Container.Instantiate<WindowFsm>();

            localWindowFsm.fsmNumber = 1;

            localWindowFsm.Set<MainMenuView>(); //Not good

            Container
                .Bind<IWindowFsm>()
                .FromInstance(localWindowFsm)
                .AsSingle()
                .NonLazy();

            _fsmProvider.Set(localWindowFsm);
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