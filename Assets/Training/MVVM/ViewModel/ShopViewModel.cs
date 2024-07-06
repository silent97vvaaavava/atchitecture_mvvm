using Assets.Training.Domain;
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
        private readonly MainMenuModel _mainMenuModel;
        protected override Type Window => typeof(ShopView);

        public event Action<List<Product>> OnProductsUpdated;

        public ShopViewModel(IWindowFsm windowFsm, ShopModel shopModel, MainMenuModel mainMenuModel) : base(windowFsm)
        {
            _model = shopModel;
            _mainMenuModel = mainMenuModel;

            _model.OnProductsUpdated += products => OnProductsUpdated?.Invoke(products);
        }

        protected override void HandleOpenedWindow(Type uiWindow)
        {
            base.HandleOpenedWindow(uiWindow);
            _model.UpdateProducts();
        }

        //protected override void HandleClosedWindow(Type uiWindow)
        //{
        //    base.HandleClosedWindow(uiWindow);
        //}

        public void BuyProduct(Product product) => _model.BuyProduct(product);

        public override void InvokeOpen() { }

        public override void InvokeClose()
        {
            _windowFsm.CloseWindow(Window);
            UnityEngine.Debug.Log("Invoke Close from ShopViewModel");
        }
    }
}