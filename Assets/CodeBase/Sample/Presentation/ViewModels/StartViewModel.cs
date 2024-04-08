using System;
using CodeBase.Core.MVVM.ViewModel;
using CodeBase.Core.MVVM.WindowFsm;
using CodeBase.Sample.Presentation.Models;
using UnityEngine;

namespace CodeBase.Sample.Presentation.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        private readonly StartModel _model;
        
        public StartViewModel(IWindowFsm windowFsm, StartModel model) : base(windowFsm)
        {
            _model = model;
        }

        
        public void InvokeOpen(Type state)
        {
            Debug.Log("Invoke to next");
            _model.OnNextState(state);
        }
        
        public override void InvokeOpen()
        {
            Debug.Log("Invoke to next");
            _model.OnNextState();
        }

        public override void InvokeClose()
        {
            
        }
    }
}