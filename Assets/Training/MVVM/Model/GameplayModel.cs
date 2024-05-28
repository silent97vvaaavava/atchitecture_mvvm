using System;
using Core.Infrastructure.GameFsm;
using Core.MVVM.Model;

namespace Training.MVVM.Model
{
    public class GameplayModel : IModel
    {
        private readonly IGameFsm _gameFsm; 
        
        public GameplayModel(IGameFsm gameFsm)
        {
            _gameFsm = gameFsm;
        }
        
        public void SwitchToState(Type state) //Go to next state
        {
            _gameFsm.Enter(state);
        }
    }
}