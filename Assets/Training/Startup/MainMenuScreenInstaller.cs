using Training.MVVM.View;
using UnityEngine;
using Zenject;

namespace Training.Startup
{
    public class MainMenuScreenInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuScreenView _mainMenuScreenView;
        
        public override void InstallBindings()
        {
            Container.Bind<MainMenuScreenView>().FromInstance(_mainMenuScreenView).AsSingle();
        }
    }
}