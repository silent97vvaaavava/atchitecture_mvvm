using Core.Domain.Providers;
using Core.Infrastructure.GameFsm;
using Core.MVVM.View;
using Core.MVVM.ViewModel;
using Training.MVVM.ViewModel;
using TypeReferences;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Training.MVVM.View
{
    public class GameplayView : BaseView<GameplayViewModel>
    {
        [SerializeField] 
        [Inherits(typeof(IExitableState))]
        private TypeReference _stateToGo;
        [SerializeField] private Button _backButton;
        
        [Inject]
        protected override void Construct(IProviderGet<IViewModel> provider)
        {
            base.Construct(provider);
            _backButton.onClick.AddListener(OnBackButtonClicked);
        }

        private void OnBackButtonClicked()
        {
            _viewModel.InvokeOpen(_stateToGo.Type);
        }
    }
}