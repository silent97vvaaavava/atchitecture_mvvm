using Core.Infrastructure;
using Core.MVVM.Windows;
using Sample.Domain.Factories;
using Sample.Infrastructure.GameFsm;
using Sample.MVVM.Model;
using Zenject;

namespace Sample.Installers
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<WindowFsm>()
                .AsSingle()
                .NonLazy();
            
            BindServices();

            BindFactories();

            BindModels();

            Container
                .BindInterfacesAndSelfTo<GameStateMachine>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindModels()
        {
            Container
                .BindInterfacesAndSelfTo<GameplayModel>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<MainMenuModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindServices()
        {
            Container
                .BindInterfacesAndSelfTo<Coroutines>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<SceneLoader>()
                .AsSingle()
                .NonLazy();
        }

        private void BindFactories()
        {
            Container
                .BindInterfacesAndSelfTo<StatesFactory>()
                .AsSingle()
                .NonLazy();
        }
    }
}