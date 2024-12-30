using Core.Samples.MVVM.Presentation.ViewModels;
using Zenject;

namespace Core.Samples.MVVM.Infrastructure
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<MenuViewModel>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<SettingsViewModel>()
                .AsSingle();
        }
    }
}