using Assets.Training.Domain.Products;

namespace Assets.Training.Domain
{
    public class Product : BaseProduct
    {
        public Product(string name, int price, bool isCoin) : base(name, price, isCoin)
        {

        }
    }
}