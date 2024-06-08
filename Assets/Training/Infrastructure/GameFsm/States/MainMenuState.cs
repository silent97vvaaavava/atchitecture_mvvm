using System.Collections;
using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using Training.Services;
using UnityEngine;

namespace Training.Infrastructure.GameFsm.States
{
    public class MainMenuState : AbstractState
    {
        private readonly SceneService _sceneLoader;
        
        private bool _isCompleted;
        
        public MainMenuState(IGameFsm gameFsm, SceneService sceneLoader) : base(gameFsm)
        {
            _sceneLoader = sceneLoader;
        }
        
        public override async void Enter()
        {
            base.Enter();
            Debug.Log("Entering MainMenuState");
            await _sceneLoader.OnLoadSceneAsync(0);
        }

        public override IEnumerator Execute()
        {
            yield return null;
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Exiting MainMenuState");
        }
    }
}