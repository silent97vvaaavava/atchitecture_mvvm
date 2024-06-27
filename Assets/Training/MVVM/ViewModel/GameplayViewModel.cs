using System;
using Core.MVVM.ViewModel;
using Core.MVVM.WindowFsm;
using Training.MVVM.Model;
using Training.MVVM.View;
using UnityEngine;

namespace Training.MVVM.ViewModel
{
    public class GameplayViewModel : BaseViewModel   
    {
        private readonly GameplayModel _model;
        protected override Type Window => typeof(GameplayView);

        public GameplayViewModel(IWindowFsm windowFsm, GameplayModel model) : base(windowFsm)
        {
            _model = model;
        }
        
        public void InvokeOpen(Type stateType)
        {
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