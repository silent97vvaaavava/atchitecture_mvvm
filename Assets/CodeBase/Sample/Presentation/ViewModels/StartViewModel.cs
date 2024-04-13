using System;
using Core.MVVM.ViewModel;
using Core.MVVM.WindowFsm;
using Sample.Presentation.Models;
using UnityEngine;

namespace Sample.Presentation.ViewModels
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