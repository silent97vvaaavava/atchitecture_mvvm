using Core.MVVM.View;

namespace Core.MVVM.WindowFsm
{
    public interface IWindowResolve
    {
        void Set<TView>() 
            where TView : class, IView;
    }
}