using Core.MVP.Presenters;
using Core.MVP.Views;
using Zenject;

namespace Core.Extensionst
{
    public static class ContainerExtensions
    {
        public static DiContainer ConstructView<TView, TPresenter>(this DiContainer container)
            where TView : ViewBase
            where TPresenter : class, IPresenter
        {
            container.Resolve<TView>().Construct(container.Resolve<TPresenter>());

            return container;
        }
    }
}