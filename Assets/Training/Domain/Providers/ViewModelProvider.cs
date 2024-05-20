using System;
using System.Collections.Generic;
using Core.Domain.Factories;
using Core.Domain.Providers;
using Core.MVVM.ViewModel;

namespace Training.Domain.Providers
{
    public class ViewModelProvider : IViewModelProvider
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly Dictionary<Type, IViewModel> _viewModels = new();

        public ViewModelProvider(IViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public TValue Get<TValue>() where TValue : class, IViewModel
        {
            var type = typeof(TValue);
            if (!_viewModels.ContainsKey(type)) 
                _viewModels[type] = _viewModelFactory.Create<TValue>();
            
            return _viewModels[type] as TValue;
        }

        public void Set<TValue>() where TValue : class, IViewModel
        {
            var type = typeof(TValue);
            if (!_viewModels.ContainsKey(type)) 
                _viewModels[type] = _viewModelFactory.Create<TValue>();
        }
    }
}