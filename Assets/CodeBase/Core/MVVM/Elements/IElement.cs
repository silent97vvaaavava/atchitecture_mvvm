namespace Core.MVVM.Elements
{
    public interface IElement<in TValue>
    where TValue : class
    {
        void Set(TValue value);
    }
    
    public interface IGraphicElement<in TValue>
    where TValue : class
    {
        void Set(TValue value);
    }
}