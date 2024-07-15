using System;

namespace Assets.Training.Domain.Products
{
    [Serializable]
    public class BaseProduct
    {
        public string Name;
        public int Price;
        public bool IsCoinProduct;

        public BaseProduct(string name, int price, bool isCoinProduct)
        {
            Name = name;
            Price = price;
            IsCoinProduct = isCoinProduct;
        }
    }
}
