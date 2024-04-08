using CodeBase.Core.Infrastructure.GameFSM;
using CodeBase.Core.Infrastructure.GameFSM.States;
using CodeBase.Sample.Services.Scene;
using UnityEngine;

namespace CodeBase.Sample.Infrastructure.GameFsm.States
{
    public class StartState : BaseState
    {
        private readonly SceneService _sceneService;

        public StartState(
            IGameFsm gameFsm, SceneService sceneService) : base(gameFsm)
        {
            _sceneService = sceneService;
        }
        
        public override void Enter()
        {
            if (!_sceneService.IsCurrentScene(0))
            {
                _sceneService
                    .OnLoadSceneAsync(0);
                Debug.Log("Open Scene");
            }
            Debug.Log("first state");
        }

        public override void Exit()
        {
            // GameFsm?.Enter<LoaderState>();
        }
    }
}