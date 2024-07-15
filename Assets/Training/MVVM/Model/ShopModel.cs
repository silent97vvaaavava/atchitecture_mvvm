using Assets.Training.Domain;
using Core.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Training.MVVM.Model;

public class ShopModel : IModel
{
    private readonly List<Product> _products;
    private readonly CurrencyModel _currencyModel;

    public event Action OnProductsUpdated;

    public ShopModel(CurrencyModel currencyModel)
    {
        _currencyModel = currencyModel;
        _products = new();
    }

    public List<Product> GetProducts()
    {
        return _products;
    }

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

    public void UpdateProducts() => OnProductsUpdated?.Invoke();

    public SaveData ReturnCurrenData()
    {
        return new SaveData
        {
            Products = _products,
            Coins = _currencyModel.CurrentCoins,
            Crystals = _currencyModel.CurrentCrystals
        };
    }

    public void LoadData(SaveData data)
    {
        _products.Clear();
        _products.AddRange(data.Products);
        _currencyModel.LoadData(data);
        UpdateProducts();
    }
}
