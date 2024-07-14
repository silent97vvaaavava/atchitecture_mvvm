using Core.Infrastructure.GameFsm;
using Core.MVVM.View;
using Sample.MVVM.ViewModel;
using TypeReferences;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Sample.MVVM.View
{
    public class GameplayView : BaseView<GameplayViewModel>
    {
        [SerializeField] 
        [Inherits(typeof(IExitableState))]
        private TypeReference _stateToGo;
        [SerializeField] private Button _backButton;
        
        [Inject]
        protected override void Construct(GameplayViewModel viewModel)
        {
            base.Construct(viewModel);
            _backButton.onClick.AddListener(OnBackButtonClicked);
        }

        private void OnBackButtonClicked()
        {
            _viewModel.SwitchToState();
        }
    }
}