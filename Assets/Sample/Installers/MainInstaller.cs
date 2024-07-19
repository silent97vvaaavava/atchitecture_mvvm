using Core.Infrastructure;
using Sample.Domain.Factories;
using Sample.Infrastructure.GameFsm;
using Zenject;
using SceneLoader = Core.Infrastructure.SceneLoader;

namespace Sample.Installers
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindServices();

            BindFactories();

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
    }
}