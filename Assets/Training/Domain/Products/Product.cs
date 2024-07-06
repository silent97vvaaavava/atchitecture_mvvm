using Assets.Training.Domain.Products;
using Core.UI.Popup;

namespace Assets.Training.Domain
{
    public class Product : BaseProduct
    {
        public Product(string name, int price) : base(name, price)
        {
        }
    }
}