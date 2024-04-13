using System;

namespace Core.MVVM.Elements
{
    public interface IAnimationElement
    {
        void Show(Action callback);
        void Hide(Action callback);
    }
}