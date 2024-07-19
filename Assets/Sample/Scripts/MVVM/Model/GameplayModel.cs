using System;
using Core.Infrastructure.GameFsm;
using Core.MVVM.Model;

namespace Sample.MVVM.Model
{
    public class GameplayModel : IModel
    {
        private readonly IGameStateMachine _gameFsm; 
        
        public GameplayModel(IGameStateMachine gameFsm)
        {
            _gameFsm = gameFsm;
        }
        
        public void SwitchToState(Type state)
        {
            _gameFsm.Enter(state);
        }
    }
}