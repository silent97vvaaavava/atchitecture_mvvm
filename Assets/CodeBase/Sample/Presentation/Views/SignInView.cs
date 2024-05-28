using Core.Domain.Providers;
using Core.MVVM.View;
using Core.MVVM.ViewModel;
using Sample.Presentation.ViewModels;
using UnityEngine;
using Zenject;

namespace Sample.Presentation.Views
{
    public class SignInView : AbstractPayloadView<SignInViewModel>
    {
        [SerializeField] private Transform _container;
        
        [Inject]
        protected override void Construct(IProviderGet<IViewModel> provider)
        {
            base.Construct(provider);
            _viewModel = provider.Get<SignInViewModel>();
        }
    }
}