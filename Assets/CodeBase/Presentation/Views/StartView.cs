using CodeBase.Infrastructure.Providers;
using CodeBase.Presentation.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Presentation.Views
{
    public class StartView : BaseView<StartViewModel>
    {
        [SerializeField] private Button _nextButton;

        protected override void Construct(ViewModelProvider provider)
        {
            base.Construct(provider);
            
            _nextButton.onClick.AddListener(_viewModel.InvokeOpen);
        }
    }
}