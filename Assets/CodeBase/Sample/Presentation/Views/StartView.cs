using CodeBase.Core.Domain.Providers;
using CodeBase.Core.Infrastructure.GameFSM;
using CodeBase.Core.MVVM.View;
using CodeBase.Core.MVVM.ViewModel;
using CodeBase.Sample.Presentation.ViewModels;
using TypeReferences;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Sample.Presentation.Views
{
    public class StartView : BaseView<StartViewModel>
    {
        [SerializeField]
        [Inherits(typeof(IExitableState))]
        private TypeReference _state;
        [SerializeField] private Button _nextButton;

        [Inject]
        protected override void Construct(IProviderGet<IViewModel> provider)
        {
            base.Construct(provider);
            _nextButton
                .onClick
                .AddListener(OnClick);
        }

        private void OnClick()
        {
            _viewModel.InvokeOpen(_state.Type);
        }
    }
}