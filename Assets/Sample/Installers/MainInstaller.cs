using Sample.Services;
using Core.Infrastructure;
using Sample.Domain.Factories;
using Sample.Domain.Providers;
using Sample.Infrastructure.GameFsm;
using Zenject;

namespace Sample.Installers
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
            Container
                .Bind<ICoroutineRunner>()
                .To<Coroutines>()
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

        private void BindProviders()
        {
            Container
                .BindInterfacesAndSelfTo<WindowFsmProvider>()
                .AsSingle()
                .WithArguments(Container)
                .NonLazy();
        }
    }
}