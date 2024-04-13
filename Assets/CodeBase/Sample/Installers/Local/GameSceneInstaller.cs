using Sample.Domain.Providers;
using Zenject;

namespace Sample.Installers.Local
{
    public class GameSceneInstaller : MonoInstaller
    {
        [Inject]
        private WindowFsmProvider _fsmProvider;
        
        public override void InstallBindings()
        {
            // Container
            //     .BindInterfacesAndSelfTo<StartModel>()
            //     .AsSingle()
            //     .NonLazy();
            //
            // BindingWindowFsm();
            // BindingProviders();
        }
    }
}