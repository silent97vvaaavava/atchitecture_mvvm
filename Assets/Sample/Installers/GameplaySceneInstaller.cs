using Core.MVVM.WindowFsm;
using Sample.Domain.Providers;
using Sample.MVVM.Model;
using Sample.MVVM.View;
using Sample.MVVM.ViewModel;
using Sample.MVVM.WindowFsm;
using Zenject;

namespace Sample.Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [Inject] private WindowFsmProvider _fsmProvider;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<GameplayModel>()
                .AsSingle()
                .NonLazy();      
            Container
                .BindInterfacesAndSelfTo<GameplayViewModel>()
                .AsSingle()
                .NonLazy();
            
            BindWindowFsm();
        }

        private void BindWindowFsm()
        {
            var localWindowFsm = Container.Instantiate<WindowFsm>();

            localWindowFsm.fsmNumber = 2;

            localWindowFsm.Set<GameplayView>();

            Container
                .Bind<IWindowFsm>()
                .FromInstance(localWindowFsm)
                .AsSingle()
                .NonLazy();

            _fsmProvider.Set(localWindowFsm);
        }
    }
}