using Core.Samples.MVP.Presentation.Presenters;
using Core.Samples.MVP.Presentation.Views;
using UnityEngine;
using Zenject;

namespace Core.Samples.MVP.Infrastructure
{
    public class MainInstallerMVP : MonoInstaller
    {
        [SerializeField] private MenuView _menuView;
        [SerializeField] private SettingsView _settingsView;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_menuView);
            Container.BindInstance(_settingsView);

            Container.Bind<MenuPresenter>().AsTransient();
            Container.Bind<SettingsPresenter>().AsTransient();
        }
    }
}