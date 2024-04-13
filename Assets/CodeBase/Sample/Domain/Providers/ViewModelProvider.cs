using System;
using System.Collections.Generic;
using Core.Domain.Factories;
using Core.Domain.Providers;
using Core.MVVM.ViewModel;
using UnityEngine;

namespace Sample.Domain.Providers
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
            {
                Debug.LogError( $"Failed! {typeof(TValue).Name} isn't resolve!");
                return null;
            }
        }

        public void Set<TValue>() where TValue : class, IViewModel
        {
            TValue value = _factory.Create<TValue>();
            Debug.Log(_viewModels.TryAdd(typeof(TValue), value) ? "Success add" : "Failed add");
        }
    }
}