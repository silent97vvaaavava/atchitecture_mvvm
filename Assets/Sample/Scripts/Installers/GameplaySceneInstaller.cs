using Sample.MVVM.ViewModel;
using Zenject;

namespace Sample.Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
             
            Container
                .BindInterfacesAndSelfTo<GameplayViewModel>()
                .AsSingle()
                .NonLazy();
        }
    }
}