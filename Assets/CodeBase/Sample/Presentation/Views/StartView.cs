using Core.Domain.Providers;
using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using Core.MVVM.View;
using Core.MVVM.ViewModel;
using Sample.Presentation.ViewModels;
using TypeReferences;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Sample.Presentation.Views
{
    public class StartView : AbstractPayloadView<StartViewModel>
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