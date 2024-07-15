using Core.MVVM.View;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using Training.Domain.Factories;
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

        private IProductViewFactory _productViewFactory;


        [Inject] 
        protected void Construct(ShopViewModel viewModel, IProductViewFactory productViewFactory)
        {
            base.Construct(viewModel);

            _productViewFactory = productViewFactory;

            _viewModel.OnProductsUpdated += UpdateProductsAsync;
            _closeButton.onClick.AddListener(OnClosedButtonClicked);
        }

        private async void UpdateProductsAsync()
        {
            foreach (Transform child in _productContainer)
                Destroy(child.gameObject);

            var products = _viewModel.GetProducts();
            foreach (var product in products)
            {
                var productView = await _productViewFactory.Create(_productContainer);
                productView.SetProduct(product);
                productView.OnBuy += () => _viewModel.BuyProduct(product);
            }
        }

        private void OnClosedButtonClicked()
        {
            _viewModel.InvokeClose();
        }
    }
}