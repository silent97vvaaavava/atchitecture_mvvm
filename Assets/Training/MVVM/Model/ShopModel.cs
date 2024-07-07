using Assets.Training;
using Assets.Training.Domain;
using Core.MVVM.Model;
using System;
using System.Collections.Generic;
using Training.MVVM.Model;

public class ShopModel : IModel
{
    private readonly List<Product> _products;
    private readonly MainMenuModel _currencyModel;

    public event Action OnProductsUpdated;

    public ShopModel(MainMenuModel currencyModel)
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
            OnProductsUpdated?.Invoke();
        }
        else if (!product.IsCoinProduct && _currencyModel.CurrentCrystals >= product.Price)
        {
            _currencyModel.SubtractCrystals(product.Price);
            _products.Remove(product);            
            OnProductsUpdated?.Invoke();
        }
    }

    //public void BuyProduct(Product product)
    //{
    //    if (_currencyModel.CurrentCoins >= product.Price)
    //    {
    //        _currencyModel.SubtractCoins(product.Price);
    //        // Logic for adding product to inventory, etc.
    //    }
    //}

    public void UpdateProducts() => OnProductsUpdated?.Invoke();
}
