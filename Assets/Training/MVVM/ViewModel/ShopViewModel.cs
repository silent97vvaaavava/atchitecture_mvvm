using Assets.Training;
using Core.MVVM.ViewModel;
using Core.MVVM.WindowFsm;
using System;
using System.Collections.Generic;
using Training.MVVM.Model;
using Training.MVVM.View;

namespace Training.MVVM.ViewModel
{
    public class ShopViewModel : BaseViewModel
    {
        private readonly ShopModel _shopModel;
        private readonly MainMenuModel _currencyModel;

        public event Action<List<Product>> OnProductsUpdated;

        public ShopViewModel(IWindowFsm windowFsm, ShopModel shopModel, MainMenuModel currencyModel) : base(windowFsm)
        {
            _shopModel = shopModel;
            _currencyModel = currencyModel;

            _shopModel.OnProductsUpdated += products => OnProductsUpdated?.Invoke(products);
        }

        public void BuyProduct(Product product) => _shopModel.BuyProduct(product);

        public override void InvokeOpen()
        {
            _shopModel.UpdateProducts();
            _windowFsm.OpenWindow(typeof(ShopView));
        }

        public override void InvokeClose() => _windowFsm.CloseWindow(typeof(ShopView));
    }
}