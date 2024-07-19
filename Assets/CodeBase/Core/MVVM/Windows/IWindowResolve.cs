using Core.MVVM.View;

namespace Core.MVVM.Windows
{
    public interface IWindowResolve
    {
        void Set<TView>() 
            where TView : class, IView;

        void CleanUp();
    }
}