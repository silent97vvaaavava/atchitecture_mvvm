using System.Collections;
using Core.Domain.Providers;
using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using Core.MVVM.WindowFsm;
using Training.MVVM.View;
using Training.Services;
using UnityEngine;

namespace Training.Infrastructure.GameFsm.States
{
    public class MainMenuState : AbstractState
    {
        private readonly SceneService _sceneLoader;
        private readonly IWindowFsm _windowFsm;
        
        private bool _isCompleted;
        
        public MainMenuState(IGameFsm gameFsm, SceneService sceneLoader, IWindowFsmProvider windowFsmProvider) : base(gameFsm)
        {
            _sceneLoader = sceneLoader;
            _windowFsm = windowFsmProvider.Local;
        }
        
        public override async void Enter()
        {
            base.Enter();   
            await _sceneLoader.OnLoadSceneAsync(0);
            _windowFsm.OpenWindow(typeof(MainMenuView));
        }

        public override IEnumerator Execute()
        {
            yield return null;
        }

        public override void Exit()
        {
            _windowFsm.CloseWindow(typeof(MainMenuView));
            base.Exit();
        }
    }
}