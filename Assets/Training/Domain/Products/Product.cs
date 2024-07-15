using Assets.Training.Domain.Products;
using System;

namespace Assets.Training.Domain
{
    [Serializable]
    public class Product : BaseProduct
    {
        public Product(string name, int price, bool isCoin) : base(name, price, isCoin)
        {
        }
    }
}
