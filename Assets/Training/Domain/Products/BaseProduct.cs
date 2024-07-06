using UnityEngine;

namespace Assets.Training.Domain.Products
{
    public class BaseProduct : MonoBehaviour, IProduct
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public BaseProduct(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}