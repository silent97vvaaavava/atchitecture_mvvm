using Core.Infrastructure;
using Training.Domain.Factories;
using Training.Domain.Providers;
using Training.Infrastructure.GameFsm;
using Training.Services;
using Unity.VisualScripting;
using Zenject;

namespace Training.Installers
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindServices();

            BindFactories();

            BindProviders();

            Container
                .BindInterfacesAndSelfTo<GameStateMachine>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindServices()
        {
            Container.Bind<ICoroutineRunner>().To<Coroutines>().AsSingle().NonLazy();

            Container
                .BindInterfacesAndSelfTo<SceneLoader>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<SceneService>()
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
                .BindInterfacesAndSelfTo<WindowFsmProvider>()
                .AsSingle()
                .WithArguments(Container)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<ViewModelProvider>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}