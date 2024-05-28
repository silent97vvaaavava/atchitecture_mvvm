using Training.Domain.Factories;
using Training.Domain.Providers;
using Training.Infrastructure.GameFsm;
using Training.MVVM.WindowFsm;
using Training.Services;
using UnityEngine;
using Zenject;

namespace Training.Installers
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindServices();
            
            //Factories
            BindFactories();
            
            //Providers
            BindProviders();
            
            //WindowFsm
            BindWindowFsm();
            
            Container
                .BindInterfacesAndSelfTo<GameStateMachine>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
        
        private void BindServices()
        {
            Container
                .BindInterfacesAndSelfTo<SceneService>()
                .AsSingle()
                .NonLazy();
        }

        private void BindWindowFsm()
        {
            Container
                .BindInterfacesAndSelfTo<WindowFsm>()
                .FromNew()
                .AsSingle()
                .NonLazy();

            var provider = Container
                .Instantiate<WindowFsmProvider>();

            Container
                .BindInterfacesAndSelfTo<WindowFsmProvider>()
                .FromInstance(provider)
                .AsSingle()
                .NonLazy();
        }

        private void BindFactories()
        {
            Container
                .BindInterfacesAndSelfTo<StatesFactory>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<ViewModelFactory>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindProviders()
        {
            Container
                .BindInterfacesAndSelfTo<ViewModelProvider>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}