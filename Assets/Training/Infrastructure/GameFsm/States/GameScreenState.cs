using System.Collections;
using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using Training.Startup;

namespace Training.Infrastructure.GameFsm.States
{
    public class GameScreenState : AbstractState
    {
        private readonly SceneLoader _sceneLoader;

        public GameScreenState(IGameFsm gameFsm, SceneLoader sceneLoader) : base(gameFsm)
        {
            _sceneLoader = sceneLoader;
        }

        public override void Enter()
        {
            _sceneLoader.LoadScene("GameScene");
            SetupEventListeners();
        }

        public override IEnumerator Execute()
        {
            yield return null;
        }

        public override void Exit()
        {
            RemoveEventListeners();
        }
        
        private void SetupEventListeners()
        {
            
        }

        private void RemoveEventListeners()
        {
            
        }
    }
}