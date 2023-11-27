using CodeBase.Domain;

namespace CodeBase.Presentation.Elements
{
    public interface IElement<in TValue>
    where TValue : class, IDto
    {
        void Set(TValue value);
    }
}