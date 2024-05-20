using System.Collections;
using Core.Domain.Providers;
using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using Training.MVVM.ViewModel;
using Training.Startup;
using UnityEngine;

namespace Training.Infrastructure.GameFsm.States
{
    public class MainMenuScreenState : AbstractState
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IViewModelProvider _viewModelProvider;
        
        private bool _isCompleted;
        
        public MainMenuScreenState(IGameFsm gameFsm, SceneLoader sceneLoader, IViewModelProvider viewModelProvider) : base(gameFsm)
        {
            _sceneLoader = sceneLoader;
            _viewModelProvider = viewModelProvider;
        }
        
        public override async void Enter()
        {
            Debug.Log("Entering MainMenuScreenState");

            await _sceneLoader.LoadScene("MainMenuScene");
            
            var viewModel = _viewModelProvider.Get<MainMenuScreenViewModel>();
            viewModel.InvokeOpen();
        }

        public override IEnumerator Execute()
        {
            yield return null;
        }

        public override void Exit()
        {
            Debug.Log("Exiting MainMenuScreenState");

            var viewModel = _viewModelProvider.Get<MainMenuScreenViewModel>();
            viewModel.InvokeClose();
        }
    }
}