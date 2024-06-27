using System;
using Core.MVVM.ViewModel;
using Core.MVVM.WindowFsm;
using Training.MVVM.Model;
using Training.MVVM.View;
using UnityEngine;

namespace Training.MVVM.ViewModel
{
    public class MainMenuViewModel : BaseViewModel
    {
        private readonly MainMenuModel _model;
        protected override Type Window => typeof(MainMenuView);
        public event Action<string> OnCoinsChanged;
        public event Action<string> OnCrystalsChanged;
        
        public MainMenuViewModel(IWindowFsm windowFsm, MainMenuModel model) : base(windowFsm)
        {
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
            Debug.Log("INDICATE CRYSTALS CHANGING");
            var amountText = amount.ToString();
            OnCrystalsChanged?.Invoke(amountText);
        }

        public void InvokeOpen(Type stateType)  // Rename to OpenNewState || SwitchToState
        { 
            _model.SwitchToState(stateType);
        }

        public override void InvokeOpen()
        {
            
        }   
        
        //TODO ВЫЗЫВАТЬ ЭТО ИЗ State. Перенести сюда логику работы с WindowFsm

        public override void InvokeClose()
        {
            //_windowFsm.CloseWindow(Window); 
        }
    }
}