using System;

namespace CodeBase.Core.MVVM.Elements
{
    public interface IAnimationElement
    {
        void Show(Action callback);
        void Hide(Action callback);
    }
}