using CodeBase.Infrastructure.Providers;
using CodeBase.Presentation.ViewModels;
using UnityEngine;
using Zenject;

namespace CodeBase.Presentation.Views
{
    public class SignInView : BaseView<SignInViewModel>
    {
        [SerializeField] private Transform _container;
        
        [Inject]
        protected override void Construct(ViewModelProvider provider)
        {
            _viewModel = provider.Get<SignInViewModel>();
        }
    }
}