using System.Collections;
using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using Cysharp.Threading.Tasks;
using Training.Services;
using UnityEngine;

namespace Training.Infrastructure.GameFsm.States
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
            base.Enter();
            Debug.Log("Enter Game");
            _sceneService.OnLoadSceneAsync("GameplayScene").Forget();
        }

        public override IEnumerator Execute()
        {
            yield return null;
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}