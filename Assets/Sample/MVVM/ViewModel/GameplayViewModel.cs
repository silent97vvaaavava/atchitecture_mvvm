using System;
using Core.Infrastructure.GameFsm;
using Core.MVVM.ViewModel;
using Core.MVVM.WindowFsm;
using Sample.Infrastructure.GameFsm.States;
using Sample.MVVM.Model;
using Sample.MVVM.View;
using TypeReferences;

namespace Sample.MVVM.ViewModel
{
    public class GameplayViewModel : BaseViewModel   
    {
        [Inherits(typeof(IExitableState))]
        private Type _stateToGo;

        private readonly GameplayModel _model;
        protected override Type Window => typeof(GameplayView);

        public GameplayViewModel(IWindowFsm windowFsm, GameplayModel model) : base(windowFsm)
        {            
            _stateToGo = typeof(MainMenuState);
            _model = model;
        }

        public void SwitchToState()
        {
            _model.SwitchToState(_stateToGo);
        }

        public void InvokeOpen(Type stateType)
        {

        }

        public override void InvokeOpen()
        {
        }

        public override void InvokeClose()
        {
      
        }
    }
}