using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class StateLoader : StateBase
    {
        private ILoadingCurtain _curtain;
        private DatabaseService _dbService;

        public StateLoader(
            IGameFsm gameFsm,
            DatabaseService dbService,
            ILoadingCurtain curtain
        ) : base(gameFsm)
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
            GameFsm.Enter<StateGameplay>();
        }
    }
}