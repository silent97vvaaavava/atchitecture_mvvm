using System;
using Core.MVVM.ViewModel;
using Core.MVVM.WindowFsm;
using Training.MVVM.Model;
using UnityEngine;

namespace Training.MVVM.ViewModel
{
    public class MainMenuViewModel : BaseViewModel
    {
        private readonly MainMenuModel _model;
        
        public MainMenuViewModel(IWindowFsm windowFsm, MainMenuModel model) : base(windowFsm)
        {
            _model = model;
        }

        public void InvokeOpen(Type stateType)  // ? Rename to OpenNewState || SwitchToState
        {
            Debug.Log($"Invoke open MainMenuModel to state: {stateType.Name}");
            _model.SwitchToState(stateType);
        }

        public override void InvokeOpen()
        {
            
        }

        public override void InvokeClose()
        {
            //_windowFsm.CloseCurrentWindow();
            //_windowFsm.CloseWindow(Window); 
        }
    }
}