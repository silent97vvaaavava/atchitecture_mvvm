using Training.MVVM.View;
using UnityEngine;
using Zenject;

namespace Training.Startup
{
    public class GameScreenInstaller : MonoInstaller
    {
        [SerializeField] private GameScreenView _gameScreenView;
        public override void InstallBindings()
        {
            Container.Bind<GameScreenView>().FromInstance(_gameScreenView).AsSingle();
        }
    }
}