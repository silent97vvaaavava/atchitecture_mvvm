using Core.MVVM.View;
using Core.Samples.MVVM.Presentation.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Samples.MVVM.Presentation.Views
{
    public class SettingsView : AbstractPayloadView<SettingsViewModel>
    {
        [SerializeField] private Button _closeButton;

        public override void Construct(SettingsViewModel viewModel)
        {
            base.Construct(viewModel);
            _closeButton.onClick.AddListener(_viewModel.InvokeClose);
        }

        protected override void OnBeforeDestroy()
        {
            _closeButton.onClick.RemoveListener(_viewModel.InvokeClose);
        }
    }
}