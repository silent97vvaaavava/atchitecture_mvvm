using System;
using Core.Infrastructure.GameFsm;
using Core.MVVM.Model;

namespace Sample.MVVM.Model
{
    public class MainMenuModel : IModel
    {
        private readonly IGameFsm _gameFsm;

        public MainMenuModel(IGameFsm gameFsm) 
        {
            _gameFsm = gameFsm;
        }

        public void SwitchToState(Type state)
        {
            _gameFsm.Enter(state);
        }
    }
}