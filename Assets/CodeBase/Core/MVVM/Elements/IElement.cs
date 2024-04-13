using Core.Data.Dto;

namespace Core.MVVM.Elements
{
    public interface IElement<in TValue>
    where TValue : class, IDto
    {
        void Set(TValue value);
    }
    
    public interface IGraphicElement<in TValue>
    where TValue : class, IDto
    {
        void Set(TValue value);
    }
}