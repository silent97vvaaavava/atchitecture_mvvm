using Core.Domain.Factories;
using Core.Domain.Providers;
using Core.Infrastructure.GameFsm;
using Training.Domain.Factories;
using Training.Domain.Providers;
using Training.Infrastructure.GameFsm;
using UnityEngine;
using Zenject;

namespace Training.Startup
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private GameBootstrapper _gameBootstrapper;

        public override void InstallBindings()
        {
            Container
                .Bind<GameBootstrapper>()
                .FromComponentInNewPrefab(_gameBootstrapper)
                .AsSingle()
                .NonLazy();
            Container
                .Bind<IGameFsm>()
                .To<GameStateMachine>()
                .AsSingle()
                .NonLazy();
            Container
                .Bind<IStatesFactory>()
                .To<StatesFactory>()
                .AsSingle()
                .NonLazy();
     
            Container.Bind<IWindowFsmProvider>().To<WindowFsmProvider>().AsSingle().NonLazy();
            Container.Bind<IViewModelProvider>().To<ViewModelProvider>().AsSingle().NonLazy();
            Container.Bind<IViewModelFactory>().To<ViewModelFactory>().AsSingle().NonLazy();
            Container.Bind<SceneLoader>().AsSingle();
        }
    }
}