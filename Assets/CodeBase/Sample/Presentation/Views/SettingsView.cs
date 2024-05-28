using Core.Domain.Providers;
using Core.MVVM.View;
using Core.MVVM.ViewModel;
using Sample.Presentation.ViewModels;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Sample.Presentation.Views
{
    public class SettingsView : AbstractPayloadView<SettingsViewModel>
    {
        [SerializeField] private Button _closeButton;
        
        [Inject]
        protected override void Construct(IProviderGet<IViewModel> provider)
        {
            base.Construct(provider);
            _closeButton.onClick.AddListener(_viewModel.InvokeClose);
        }
    }
}