using CodeBase.Infrastructure.Providers;
using CodeBase.Presentation.ViewModels;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Presentation.Views
{
    public class SettingsView : BaseView<SettingsViewModel>
    {
        [SerializeField] private Button _closeButton;
        
        [Inject]
        protected override void Construct(ViewModelProvider provider)
        {
            base.Construct(provider);
        }
    }
}