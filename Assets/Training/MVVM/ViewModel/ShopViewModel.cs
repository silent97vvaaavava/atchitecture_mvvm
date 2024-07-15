using Assets.Training.Domain;
using Core.MVVM.ViewModel;
using Core.MVVM.WindowFsm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Training.MVVM.View;

namespace Training.MVVM.ViewModel
{
    public class ShopViewModel : BaseViewModel
    {
        private readonly ShopModel _model;
        private readonly SaveModel _saveModel;
        protected override Type Window => typeof(ShopView);

        public event Action OnProductsUpdated;

        public ShopViewModel(IWindowFsm windowFsm, ShopModel shopModel, SaveModel saveModel) : base(windowFsm)
        {
            _model = shopModel;
            _saveModel = saveModel;

            _model.OnProductsUpdated += UpdateViewProducts;
        }

        public List<Product> GetProducts() => _model.GetProducts();

        protected override void HandleOpenedWindow(Type uiWindow)   
        {
            base.HandleOpenedWindow(uiWindow);
            if (uiWindow != Window) return;

            LoadData();
        }

        protected override void HandleClosedWindow(Type uiWindow)
        {
            base.HandleClosedWindow(uiWindow);
            if (uiWindow != Window) return;

            SaveData();
        }

        private void UpdateViewProducts() => OnProductsUpdated?.Invoke();

        public void BuyProduct(Product product) => _model.BuyProduct(product);

        public override void InvokeOpen() { }

        public override void InvokeClose()
        {
            _windowFsm.CloseWindow(Window);
        }

        private void LoadData()
        {
            var saveData = _saveModel.Load();
            _model.LoadData(saveData);
        }

        private void SaveData()
        {
            var saveData = _model.ReturnCurrenData();
            _saveModel.Save(saveData);
        }
    }
}