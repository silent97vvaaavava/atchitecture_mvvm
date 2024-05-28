using Core.MVVM.Windows;
using Sample.Domain.Factories;
using Sample.Domain.Providers;
using Sample.Presentation.Models;
using Sample.Presentation.ViewModels;
using Sample.Presentation.Views;
using Zenject;

namespace Sample.Installers.Local
{
    public class StartSceneInstaller : MonoInstaller
    {
        [Inject]
        private WindowFsmProvider _fsmProvider;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<StartModel>()
                .AsSingle()
                .NonLazy();
            
            BindingWindowFsm();
            BindingProviders();
        }

        private void BindingWindowFsm()
        {
            var local = Container
                .Instantiate<WindowFsm>();

            local.Set<StartView>(); // Bad practice
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

            provider.Set<StartViewModel>();
            provider.Set<SettingsViewModel>();
        }
    }
}