using Training.Domain.Factories;
using Training.Domain.Providers;
using Training.MVVM.Model;
using Training.MVVM.View;
using Training.MVVM.ViewModel;
using Training.MVVM.WindowFsm;
using Zenject;

namespace Training.Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [Inject] private WindowFsmProvider _fsmProvider;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<GameplayModel>()
                .AsSingle()
                .NonLazy();
            
            BindWindowFsm();
            BindProviders();
        }     
        
        private void BindWindowFsm()
        {
            var localWindowFsm = Container.Instantiate<WindowFsm>();
            
            localWindowFsm.Set<GameplayView>(); //Not good

            Container
                .BindInterfacesAndSelfTo<WindowFsm>()
                .FromInstance(localWindowFsm)
                .AsCached()
                .NonLazy();
            
            _fsmProvider.Set(localWindowFsm );
        }

        private void BindProviders()
        {
            Container
                .BindInterfacesAndSelfTo<ViewModelFactory>()
                .FromNew()
                .AsSingle()
                .NonLazy();
            
            var provider = Container
                .Instantiate<ViewModelProvider>();
            
            Container
                .BindInterfacesAndSelfTo<ViewModelProvider>()
                .FromInstance(provider)
                .AsSingle()
                .NonLazy();
            
            provider.Set<GameplayViewModel>();
        }
    }
}