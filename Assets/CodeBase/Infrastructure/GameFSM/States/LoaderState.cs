using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class LoaderState : BaseState
    {
        private ILoadingCurtain _curtain;
        private DatabaseService _dbService;

        public LoaderState(
            IGameStateMachine gameStateMachine,
            DatabaseService dbService,
            ILoadingCurtain curtain
        ) : base(gameStateMachine)
        {
            _dbService = dbService;
            _curtain = curtain;
        }

        public override async void Enter()
        {
            // await _dbService.InitializeAsync(_curtain.Progress);
        }

        public override void Exit()
        {
            _gameStateMachine.Enter<GameplayState>();
        }
    }
}