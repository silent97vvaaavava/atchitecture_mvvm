using CodeBase.Core.Data.Dto;

namespace CodeBase.Core.MVVM.Elements
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