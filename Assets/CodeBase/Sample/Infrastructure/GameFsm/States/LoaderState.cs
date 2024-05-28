using System.Threading.Tasks;
using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using UnityEngine;

namespace Sample.Infrastructure.GameFsm.States
{
    public class LoaderState : AbstractState, IAsyncState
    {
        public LoaderState(IGameStateMachine gameStateMachine) : base(gameStateMachine) { }

        public async Task OnEnterAsync()
        {
            Debug.Log("Enter Loader");
            GameStateMachine?.Enter<GameplayState>();
        }

        public override void OnExit()
        {
            Debug.Log("Exit Loader");
        }
    }
}