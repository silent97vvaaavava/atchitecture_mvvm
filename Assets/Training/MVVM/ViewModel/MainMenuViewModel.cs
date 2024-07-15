using System;
using System.Diagnostics;
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
        private SaveModel _saveModel;
        private readonly MainMenuModel _model;
        private readonly CurrencyModel _currencyModel;
        protected override Type Window => typeof(MainMenuView);

        public event Action<string> OnCoinsChanged;
        public event Action<string> OnCrystalsChanged;
        
        public MainMenuViewModel(IWindowFsm windowFsm, MainMenuModel model, CurrencyModel currencyModel, SaveModel saveModel) : base(windowFsm)
        {
            _stateToGo = typeof(GameplayState);

            _model = model;
            _currencyModel = currencyModel;
            _saveModel = saveModel;

            _currencyModel.OnCoinsChanged += IndicateCoinsChanging;
            _currencyModel.OnCrystalsChanged += IndicateCrystalsChanging;
        }

        protected override void HandleOpenedWindow(Type uiWindow)
        {
            base.HandleOpenedWindow(uiWindow);
            IndicateCoinsChanging(_currencyModel.CurrentCoins);
            IndicateCrystalsChanging(_currencyModel.CurrentCrystals);
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

        public override void InvokeOpen()   //Rename to OnOpened 
        {
            
        }   
        
        public override void InvokeClose()  //Rename to CloseWindow
        {
            //_windowFsm.CloseWindow(Window); 
        }

        private void LoadData()
        {
            var saveData = _saveModel.Load();
            _currencyModel.LoadData(saveData);
        }

        private void SaveData()
        {
            var saveData = _currencyModel.GetSaveData();
            _saveModel.Save(saveData);
        }
    }
}