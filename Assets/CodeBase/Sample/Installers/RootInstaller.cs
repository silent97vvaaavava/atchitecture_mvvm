using CodeBase.Sample.Domain.Factories;
using CodeBase.Sample.Domain.Providers;
using CodeBase.Sample.Infrastructure.GameFsm;
using CodeBase.Sample.Presentation.Models;
using CodeBase.Sample.Presentation.Views;
using CodeBase.Sample.Presentation.WindowFSM;
using CodeBase.Sample.Services.Scene;
using UnityEngine;
using Zenject;

namespace CodeBase.Sample.Installers
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