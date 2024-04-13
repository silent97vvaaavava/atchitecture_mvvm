using Sample.Domain.Factories;
using Sample.Domain.Providers;
using Sample.Infrastructure.GameFsm;
using Sample.Presentation.Models;
using Sample.Presentation.Views;
using Sample.Presentation.WindowFSM;
using Sample.Services.Scene;
using UnityEngine;
using Zenject;

namespace Sample.Installers
{
    public class RootInstaller : MonoInstaller
    {
        [SerializeField] private CurtainView _curtain;

        public override void InstallBindings()
        {
            CurtainView curtainView = Container
                .InstantiatePrefabForComponent<CurtainView>(_curtain); // ToDo: Instantiate set after Resolve
            
            Container
                .BindInterfacesAndSelfTo<InternetReachabilityModel>()
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