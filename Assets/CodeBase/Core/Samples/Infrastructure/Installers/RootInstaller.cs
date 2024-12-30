using Core.Samples.Infrastructure.GameFsm;
using Zenject;

namespace Core.Samples.Infrastructure.Installers
{
    public class RootInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<StateFactory>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<GameStateMachine>()
                .AsSingle();
        }
    }
}