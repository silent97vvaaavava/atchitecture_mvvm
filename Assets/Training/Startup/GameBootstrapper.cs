using Core.Infrastructure.GameFsm;
using Training.Infrastructure.GameFsm;
using Training.Infrastructure.GameFsm.States;
using UnityEngine;
using Zenject;

namespace Training.Startup
{
    public class GameBootstrapper : MonoBehaviour
    {
        [Inject] private IGameFsm _gameFsm; 
        
        private void Start()
        {
            (_gameFsm as GameStateMachine)?.RegisterStates();   //TODO Костыль из-за Circular Dependency Exceptions

            _gameFsm.Enter<MainMenuScreenState>();
            DontDestroyOnLoad(this);
        }
    }
}