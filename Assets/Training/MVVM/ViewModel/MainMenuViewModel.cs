using System;
using Core.Infrastructure.GameFsm;
using Core.MVVM.ViewModel;
using Core.MVVM.WindowFsm;
using Training.Infrastructure.GameFsm.States;
using Training.MVVM.Model;
using Training.MVVM.View;
using TypeReferences;

namespace Training.MVVM.ViewModel
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
            _model.OnCoinsChanged += IndicateCoinsChanging;
            _model.OnCrystalsChanged += IndicateCrystalsChanging;
        }

        protected override void HandleOpenedWindow(Type uiWindow)
        {
            base.HandleOpenedWindow(uiWindow);
            IndicateCoinsChanging(_model.CurrentCoins);
            IndicateCrystalsChanging(_model.CurrentCrystals);
        }

        private void IndicateCoinsChanging(int amount)    // Or rename to HandleCoinsChanged?
        {
            var amountText = amount.ToString();
            OnCoinsChanged?.Invoke(amountText);
        }

        private void IndicateCrystalsChanging(int amount)
        {
            var amountText = amount.ToString();
            OnCrystalsChanged?.Invoke(amountText);
        }

        public void OpenShop()
        {
            _windowFsm.OpenOneWindow(typeof(ShopView));
        }
        public void OpenSettings()
        {
            _windowFsm.OpenOneWindow(typeof(SettingsView));
        }

        public void SwitchToState()  // Rename to OpenNewState || SwitchToState
        {
            _model.SwitchToState(_stateToGo);
        }

        public void InvokeOpen(Type type) { }

        public override void InvokeOpen()
        {
            
        }   
        
        public override void InvokeClose()
        {
            //_windowFsm.CloseWindow(Window); 
        }
    }
}