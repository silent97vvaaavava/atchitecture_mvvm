namespace Assets.Training
{
    public interface IProduct
    {
        string Name { get; }
        int Price { get; }
        bool IsCoinProduct { get; }
    }
}