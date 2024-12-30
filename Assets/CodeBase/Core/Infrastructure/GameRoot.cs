using Core.Infrastructure.GameFsm;
using UnityEngine;
using Zenject;

namespace Core.Infrastructure
{
    public class GameRoot : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(IGameStateMachine gameStateMachine)
        {
            DontDestroyOnLoad(gameObject);

            _gameStateMachine = gameStateMachine;
            _gameStateMachine.Initialize();
        }
    }
}