using CodeBase.Helpers;
using CodeBase.Infrastructure;
using CodeBase.Presentation.Views;
using CodeBase.Services;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers
{
    public class RootInstaller : MonoInstaller
    {
        [SerializeField] private LoadingCurtainView _curtain;

        public override void InstallBindings()
        {
            LoadingCurtainView curtainView = Container
                .InstantiatePrefabForComponent<LoadingCurtainView>(_curtain);
            
            Container
                .BindInterfacesAndSelfTo<InternetReachability>()
                .FromNew()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<LoadingCurtainView>()
                .FromInstance(curtainView)
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<DatabaseService>()
                .FromNew()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<GameStateMachine>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}