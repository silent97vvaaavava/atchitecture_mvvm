using CodeBase.Core.Infrastructure.GameFSM;
using CodeBase.Core.Infrastructure.GameFSM.States;
using CodeBase.Sample.Services.Scene;
using UnityEngine;

namespace CodeBase.Sample.Infrastructure.GameFsm.States
{
    public class GameplayState : BaseState
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

        public override void Exit()
        {
            base.Exit();
        }

        private void Initialize()
        {

        }
    }
}