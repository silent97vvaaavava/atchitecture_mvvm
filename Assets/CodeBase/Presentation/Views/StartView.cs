using System;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Providers;
using CodeBase.Presentation.ViewModels;
using TypeReferences;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Presentation.Views
{
    public class StartView : BaseView<StartViewModel>
    {
        [SerializeField] private int _scene;
        [SerializeField]
        [Inherits(typeof(IExitableState))]
        private TypeReference _state;
        [SerializeField] private Button _nextButton;

        [Inject]
        protected override void Construct(ViewModelProvider provider)
        {
            base.Construct(provider);
            
            _nextButton
                .onClick
                .AddListener(_viewModel.InvokeOpen);
        }

        private void OnClick()
        {
            _viewModel.InvokeOpen(_scene);
        }
    }
}