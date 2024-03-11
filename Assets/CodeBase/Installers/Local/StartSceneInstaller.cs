using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.Providers;
using CodeBase.Presentation;
using CodeBase.Presentation.ViewModels;
using CodeBase.Presentation.Views;
using Zenject;

namespace CodeBase.Installers.Local
{
    public class StartSceneInstaller : MonoInstaller
    {
        [Inject]
        private WindowFsmProvider _fsmProvider;
        
        public override void InstallBindings()
        {
            BindingWindowFsm();
            BindingProviders();
        }

        private void BindingWindowFsm()
        {
            var local = Container
                .Instantiate<WindowFsm>();

            local.Set<SettingsView>();
            
            Container
                .BindInterfacesAndSelfTo<WindowFsm>()
                .FromInstance(local)
                .AsSingle()
                .NonLazy();

            _fsmProvider
                .Set(local);
        }
        
        private void BindingProviders()
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

            provider.Set<SettingsViewModel>();
        }
    }
}