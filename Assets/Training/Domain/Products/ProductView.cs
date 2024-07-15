using Assets.Training.Domain;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Training.Domain.Products
{
    public class ProductView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Image coinIcon;
        [SerializeField] private Image crystalIcon;

        public event Action OnBuy;

        public void SetProduct(Product product)
        {
            _nameText.text = product.Name;
            _priceText.text = product.Price.ToString();
            _buyButton.onClick.AddListener(() => OnBuy?.Invoke());

            if (product.IsCoinProduct)
            {
                coinIcon.enabled = true;
                crystalIcon.enabled = false;
            }
            else
            {
                coinIcon.enabled = false;
                crystalIcon.enabled = true;
            }
        }
    }
}
