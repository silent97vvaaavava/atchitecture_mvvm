using Assets.Training;
using Core.MVVM.Model;
using System;
using System.Collections.Generic;
using Training.MVVM.Model;

public class ShopModel : IModel
{
    private readonly List<Product> _products;
    private readonly MainMenuModel _currencyModel;

    public event Action<List<Product>> OnProductsUpdated;

    public ShopModel(MainMenuModel currencyModel)
    {
        _currencyModel = currencyModel;
        _products = new List<Product>
        {
            new Product("Item 1", 10),
            new Product("Item 2", 20),
            new Product("Item 3", 30)
        };
    }

    public List<Product> GetProducts() => _products;

    public void BuyProduct(Product product)
    {
        if (_currencyModel.CurrentCoins >= product.Price)
        {
            _currencyModel.SubtractCoins(product.Price);
            // Logic for adding product to inventory, etc.
        }
    }

    public void UpdateProducts() => OnProductsUpdated?.Invoke(_products);
}
