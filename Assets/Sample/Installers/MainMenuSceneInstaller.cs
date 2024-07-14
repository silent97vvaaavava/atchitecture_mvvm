using Core.MVVM.WindowFsm;
using Sample.Domain.Providers;
using Sample.MVVM.Model;
using Sample.MVVM.View;
using Sample.MVVM.ViewModel;
using Sample.MVVM.WindowFsm;
using Zenject;

namespace Training.Installers
{
    public class MainMenuSceneInstaller : MonoInstaller
    {
        [Inject] private WindowFsmProvider _fsmProvider;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<MainMenuModel>()
                .AsSingle()
                .NonLazy();
            Container
                .BindInterfacesAndSelfTo<MainMenuViewModel>()
                .AsSingle()
                .NonLazy();

            BindSettings();

            BindWindowFsm();
        }

        private void BindSettings()
        {
            Container
                .BindInterfacesAndSelfTo<SettingsViewModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindWindowFsm()
        {
            var localWindowFsm = Container.Instantiate<WindowFsm>();

            localWindowFsm.fsmNumber = 1;

            localWindowFsm.Set<MainMenuView>();
            localWindowFsm.Set<SettingsView>();

            Container
                .Bind<IWindowFsm>()
                .FromInstance(localWindowFsm)
                .AsSingle()
                .NonLazy();

            _fsmProvider.Set(localWindowFsm);
        }
    }
}
