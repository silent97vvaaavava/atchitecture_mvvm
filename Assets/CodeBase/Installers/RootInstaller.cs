using CodeBase.Helpers;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.Providers;
using CodeBase.Presentation;
using CodeBase.Presentation.Views;
using CodeBase.Services;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers
{
    public class RootInstaller : MonoInstaller
    {
        [SerializeField] private CurtainView _curtain;

        public override void InstallBindings()
        {
            CurtainView curtainView = Container
                .InstantiatePrefabForComponent<CurtainView>(_curtain);
            
            Container
                .BindInterfacesAndSelfTo<InternetReachability>()
                .FromNew()
                .AsSingle()
                .NonLazy();

            BindingService();
            
            // Factory 
            BindingFactory();
            
            // Providers
            BindingProviders();
            
            // Window Fsm 
            BindingWindowFsm();
            
            Container
                .BindInterfacesAndSelfTo<CurtainView>()
                .FromInstance(curtainView)
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<DatabaseService>()
                .FromNew()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<GameFsm>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindingService()
        {
            Container
                .BindInterfacesAndSelfTo<SceneService>()
                .AsSingle()
                .NonLazy();
        }

        private void BindingWindowFsm()
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

        private void BindingFactory()
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

        private void BindingProviders()
        {
            Container
                .BindInterfacesAndSelfTo<ViewModelProvider>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}