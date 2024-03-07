using CodeBase.Infrastructure.Providers;
using CodeBase.Presentation.ViewModels;
using UnityEngine;
using Zenject;

namespace CodeBase.Presentation.Views
{
    public class SettingsView : BaseView<SettingsViewModel>
    {
        [Inject]
        protected override void Construct(ViewModelProvider provider)
        {
            base.Construct(provider);
        }
    }
}