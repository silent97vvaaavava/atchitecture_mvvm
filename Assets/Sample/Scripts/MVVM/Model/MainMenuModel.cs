using System;
using Core.Infrastructure.GameFsm;
using Core.MVVM.Model;

namespace Sample.MVVM.Model
{
    public class MainMenuModel : IModel
    {
        private readonly IGameStateMachine _gameFsm;

        public MainMenuModel(IGameStateMachine gameFsm) 
        {
            _gameFsm = gameFsm;
        }

        public void SwitchToState(Type state)
        {
            _gameFsm.Enter(state);
        }
    }
}