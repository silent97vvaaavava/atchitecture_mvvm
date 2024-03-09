using System;

namespace CodeBase.Presentation.Elements
{
    public interface IAnimationElement
    {
        void Show(Action callback);
        void Hide(Action callback);
    }
}