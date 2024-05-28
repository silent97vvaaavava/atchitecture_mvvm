using System;
using Core.Infrastructure.GameFsm;
using Core.MVVM.Model;
using Training.Services;

namespace Training.MVVM.Model
{
    public class MainMenuModel : IModel
    {
        private readonly IGameFsm _gameFsm; 
        
        public MainMenuModel(IGameFsm gameFsm)
        {
            _gameFsm = gameFsm;
        }

        // public void SwitchToState()
        // {
        //     // _sceneService
        //     //     .OnLoadSceneAsync(1);
        //     _gameFsm.Enter<LoaderState>();
        // }
        //
        // public void SwitchToState(int scene)
        // {
        //     // _sceneService
        //     //     .OnLoadSceneAsync(scene);
        //     
        //     _gameFsm.Enter<LoaderState>();
        // }
        
        public void SwitchToState(Type state) //Go to next state
        {
            _gameFsm.Enter(state);
        }
    }
}