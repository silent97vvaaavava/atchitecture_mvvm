using CodeBase.Core.Domain.Providers;
using CodeBase.Core.MVVM.View;
using CodeBase.Core.MVVM.ViewModel;
using CodeBase.Sample.Presentation.ViewModels;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Sample.Presentation.Views
{
    public class SettingsView : BaseView<SettingsViewModel>
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