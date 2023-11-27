using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Factories;
using CodeBase.Presentation.ViewModels;
using UnityEngine;

namespace CodeBase.Infrastructure.Providers
{
    public class ViewModelProvider : IViewModelProvider 
    {
        private readonly Dictionary<Type, IViewModel> _viewModels = new Dictionary<Type, IViewModel>();
        private readonly IViewModelFactory _factory;

        public ViewModelProvider(IViewModelFactory factory)
        {
            _factory = factory;
        }
        
        public TValue Get<TValue>() where TValue : class, IViewModel
        {
            if (_viewModels.TryGetValue(typeof(TValue), out IViewModel value))
                return value as TValue;
            else
                return null;
        }

        public void Set<TValue>() where TValue : class, IViewModel
        {
            TValue value = _factory.Create<TValue>();
            if(_viewModels.TryAdd(typeof(TValue), value))
                Debug.Log("Success add");
            else 
                Debug.Log("Failed add");
        }
    }
}