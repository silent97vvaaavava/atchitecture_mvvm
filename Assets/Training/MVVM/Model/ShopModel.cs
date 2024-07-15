using Assets.Training.Domain;
using Core.MVVM.Model;
using System;
using System.Collections.Generic;
using Training.MVVM.Model;

public class ShopModel : IModel
{
    private readonly List<Product> _products;
    private readonly CurrencyModel _currencyModel;

    public event Action OnProductsUpdated;

    public ShopModel(CurrencyModel currencyModel)
    {
        _currencyModel = currencyModel;
        _products = new List<Product>
        {
            new Product("Item 1", 10, false),
            new Product("Item 2", 20, true),
            new Product("Item 3", 30, false)
        };
    }

    public List<Product> GetProducts() => _products;

    public void BuyProduct(Product product)
    {
        if (product.IsCoinProduct && _currencyModel.CurrentCoins >= product.Price)
        {
            _currencyModel.SubtractCoins(product.Price);
            _products.Remove(product);
            UpdateProducts();
        }
        else if (!product.IsCoinProduct && _currencyModel.CurrentCrystals >= product.Price)
        {
            _currencyModel.SubtractCrystals(product.Price);
            _products.Remove(product);
            UpdateProducts();
        }
    }

    public void UpdateProducts()
    {
        UnityEngine.Debug.Log("UpdateProducts action had been invoked in ShopModel");
        OnProductsUpdated?.Invoke();
    }
}
