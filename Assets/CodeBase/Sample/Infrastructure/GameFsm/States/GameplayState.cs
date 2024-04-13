using System.Collections;
using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using Sample.Services.Scene;
using UnityEngine;

namespace Sample.Infrastructure.GameFsm.States
{
    public class GameplayState : AbstractState
    {
        private readonly SceneService _sceneService;
        
        public GameplayState(IGameFsm gameFsm, SceneService sceneService) : base(gameFsm)
        {
            _sceneService = sceneService;
        }

        public override void Enter()
        {
            Debug.Log("Enter Game");
            _sceneService
                .OnLoadSceneAsync(1);
        }

        public override IEnumerator Execute()
        {
            yield return null;
        }

        public override void Exit()
        {
            base.Exit();
        }

        private void Initialize()
        {

        }
    }
}