using Core.MVP.Presenters;

namespace Core.MVP.Views
{
    public interface IView
    {
        void Construct(IPresenter presenter);
    }
}