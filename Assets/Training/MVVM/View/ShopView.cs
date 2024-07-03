using System.Collections.Generic;
using Assets.Training;
using Core.MVVM.View;
using Training.MVVM.ViewModel;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Training.MVVM.View
{
    public class ShopView : BaseView<ShopViewModel>
    {
        [SerializeField] private Transform _productContainer;
        [SerializeField] private GameObject _productPrefab;
        [SerializeField] private Button _closeButton;

        [Inject]
        protected override void Construct(ShopViewModel viewModel)
        {
            base.Construct(viewModel);

            _viewModel.OnProductsUpdated += DisplayProducts;
            _closeButton.onClick.AddListener(() => _viewModel.InvokeClose());
        }

        private void DisplayProducts(List<Product> products)
        {
            foreach (Transform child in _productContainer)
            {
                Destroy(child.gameObject);
            }

            foreach (var product in products)
            {
                var productInstance = Instantiate(_productPrefab, _productContainer);
                var productView = productInstance.GetComponent<ProductView>();
                productView.SetProduct(product);
                productView.OnBuy += () => _viewModel.BuyProduct(product);
            }
        }
    }
}