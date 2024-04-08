using CodeBase.Core.MVVM.View;

namespace CodeBase.Core.MVVM.WindowFsm
{
    public interface IWindowResolve
    {
        void Set<TView>() 
            where TView : class, IView;
    }
}