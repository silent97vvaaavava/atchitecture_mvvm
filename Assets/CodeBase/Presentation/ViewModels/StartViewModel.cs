using CodeBase.Presentation.Models;
using UnityEngine;

namespace CodeBase.Presentation.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        private readonly StartModel _model;
        
        public StartViewModel(IWindowFsm windowFsm, StartModel model) : base(windowFsm)
        {
            _model = model;
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