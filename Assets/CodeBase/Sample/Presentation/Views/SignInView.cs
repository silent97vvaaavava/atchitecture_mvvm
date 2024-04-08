using CodeBase.Core.Domain.Providers;
using CodeBase.Core.MVVM.View;
using CodeBase.Core.MVVM.ViewModel;
using CodeBase.Sample.Presentation.ViewModels;
using UnityEngine;
using Zenject;

namespace CodeBase.Sample.Presentation.Views
{
    public class SignInView : BaseView<SignInViewModel>
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