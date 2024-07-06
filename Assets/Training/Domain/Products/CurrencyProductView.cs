using Assets.Training.Domain;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyProductView : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Button _buyButton;

    public event Action OnBuy;

    public void SetProduct(Product product)
    {
        _nameText.text = product.Name;
        _priceText.text = product.Price.ToString();
        _buyButton.onClick.AddListener(() => OnBuy?.Invoke());
    }
}
