using UnityEngine;

namespace Assets.Training.Domain.Products
{
    public class BaseProduct : IProduct
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public bool IsCoinProduct { get; private set; }

        public BaseProduct(string name, int price, bool isCoinProduct)
        {
            Name = name;
            Price = price;
            IsCoinProduct = isCoinProduct;
        }
    }
}