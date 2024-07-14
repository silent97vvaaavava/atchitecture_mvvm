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
    public class MainMenuViewModel : BaseViewModel
    {
        [Inherits(typeof(IExitableState))]
        private Type _stateToGo;
        private readonly MainMenuModel _model;
        protected override Type Window => typeof(MainMenuView);

        public event Action<string> OnCoinsChanged;
        public event Action<string> OnCrystalsChanged;
        
        public MainMenuViewModel(IWindowFsm windowFsm, MainMenuModel model) : base(windowFsm)
        {
            _stateToGo = typeof(GameplayState);

            _model = model;
        }

        private void IndicateCoinsChanging(int amount)
        {
            var amountText = amount.ToString();
            OnCoinsChanged?.Invoke(amountText);
        }

        private void IndicateCrystalsChanging(int amount)
        {
            var amountText = amount.ToString();
            OnCrystalsChanged?.Invoke(amountText);
        }

        public void OpenSettings()
        {
            _windowFsm.OpenOneWindow(typeof(SettingsView));
        }

        public void SwitchToState()
        {
            _model.SwitchToState(_stateToGo);
        }

        public void InvokeOpen(Type type) { }

        public override void InvokeOpen()
        {
            
        }   
        
        public override void InvokeClose()
        {
      
        }
    }
}