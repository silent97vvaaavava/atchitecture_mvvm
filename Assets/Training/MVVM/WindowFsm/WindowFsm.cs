using System;
using System.Collections.Generic;
using Core.MVVM.View;
using Core.MVVM.WindowFsm;
using UnityEngine;
using Zenject;

namespace Training.MVVM.WindowFsm
{
    public class WindowFsm : IWindowFsm, IWindowResolve
    {
        public event Action<Type> Opened;
        public event Action<Type> Closed;

        private readonly Dictionary<Type, Window> _windows = new();    
        private readonly Stack<Type> _windowHistory = new();
        private readonly DiContainer _container;

        public WindowFsm(DiContainer container)
        {
            _container = container;
        }

        public Type CurrentWindow { get; private set; }
        public bool IsOpenWindow => CurrentWindow != null;

        public void OpenWindow(Type type)
        {
            if (IsOpenWindow) 
                CloseCurrentWindow();

            if (_windows.TryGetValue(type, out var window))
            {
                CurrentWindow = type;
                window.Open();
                _windowHistory.Push(type);
                Opened?.Invoke(type);
            }
            else
                Debug.LogError($"Window of type {type} is not registered.");
        }

        public void OpenOneWindow(Type window)
        {
            CloseCurrentWindow();
            OpenWindow(window);
        }

        public void CloseWindow(Type type)
        {
            if (CurrentWindow == type)
            {
                CloseCurrentWindow();
            }
            else if (_windows.TryGetValue(type, out var window))
            {
                window.Close();
                Closed?.Invoke(type);
            }
        }

        public void CloseCurrentWindow()
        {
            if (CurrentWindow == null || !_windows.TryGetValue(CurrentWindow, out var window)) return;
            window.Close();
            Closed?.Invoke(CurrentWindow);
            CurrentWindow = null;
        }

        public void ClearHistory()
        {
            _windowHistory.Clear(); 
            CurrentWindow = null;
        }
        
        public void Set<TView>() where TView : class, IView //TODO Разобраться с созданием вьюшек
        {
            // var factory = _container.Resolve<PlaceholderFactory<TView>>();
            // var view = factory.Create();
            
            var type = typeof(TView);
            if (_windows.ContainsKey(type)) return;
            var view = _container.Instantiate<TView>();
            var window = new Window(type);
            window.Opened += _ => view.Show();
            window.Closed += _ => view.Hide();
            _windows.Add(type, window);
        }
    }
}
