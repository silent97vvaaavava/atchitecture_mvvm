using Sample.MVVM.ViewModel;
using Zenject;

namespace Training.Installers
{
    public class MainMenuSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<MainMenuViewModel>()
                .AsSingle()
                .NonLazy();

            BindSettings();
        }

        private void BindSettings()
        {
            Container
                .BindInterfacesAndSelfTo<SettingsViewModel>()
                .AsSingle()
                .NonLazy();
        }
    }
}
