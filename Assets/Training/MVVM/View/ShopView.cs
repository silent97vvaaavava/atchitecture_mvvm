using System.Collections.Generic;
using Assets.Training.Domain;
using Core.MVVM.View;
using Training.Domain.Factories;
using Training.MVVM.ViewModel;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Training.MVVM.View
{
    public class ShopView : BaseView<ShopViewModel>
    {
        [Inject] private ProductViewFactory _productViewFactory;

        [SerializeField] private Transform _productContainer;
        [SerializeField] private GameObject _productPrefab;
        [SerializeField] private Button _closeButton;

        [Inject]
        protected override void Construct(ShopViewModel viewModel/*, CurrencyProduct currencyProduct*/)
        {
            base.Construct(viewModel);

            _viewModel.OnProductsUpdated += UpdateProducts;
            _closeButton.onClick.AddListener(() => _viewModel.InvokeClose());
        }

        private void UpdateProducts()
        {
            foreach (Transform child in _productContainer)
            {
                Destroy(child.gameObject);
            }

            var products = _viewModel.GetProducts();
            foreach (var product in products)
            {
                var productView = _productViewFactory.Create(_productContainer);
                productView.SetProduct(product);
                productView.OnBuy += () => _viewModel.BuyProduct(product);
            }
        }
    }
}