﻿using Assets.Training.Domain;
using Core.MVVM.ViewModel;
using Core.MVVM.WindowFsm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Training.MVVM.Model;
using Training.MVVM.View;

namespace Training.MVVM.ViewModel
{
    public class ShopViewModel : BaseViewModel
    {
        private readonly ShopModel _model;
        private readonly CurrencyModel _currencyModel;
        protected override Type Window => typeof(ShopView);

        public event Action OnProductsUpdated;

        public ShopViewModel(IWindowFsm windowFsm, ShopModel shopModel) : base(windowFsm)
        {
            _model = shopModel;

            _model.OnProductsUpdated += UpdateViewProducts;
        }

        public List<Product> GetProducts() => _model.GetProducts();

        //TODO Переместить в InvokeOpen. Так делать нельзя, ведь этот метод вызывается на открытие любого окна
        protected override void HandleOpenedWindow(Type uiWindow)   
        {
            base.HandleOpenedWindow(uiWindow);
            UpdateViewProducts();
            UnityEngine.Debug.Log("HANDLEOPENEDWINDOW");
        }



        private void UpdateViewProducts()
        {
            OnProductsUpdated?.Invoke();
        }

        public void BuyProduct(Product product) => _model.BuyProduct(product);

        public override void InvokeOpen() { }

        public override void InvokeClose()
        {
            _windowFsm.CloseWindow(Window);
        }
    }
}