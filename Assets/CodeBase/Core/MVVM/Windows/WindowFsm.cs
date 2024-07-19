using System;
using System.Collections.Generic;
using Core.MVVM.View;
using UnityEngine;

namespace Core.MVVM.Windows
{
    public class WindowFsm : IWindowFsm, IWindowResolve
    {
        public event Action<Type> Opened;
        public event Action<Type> Closed;

        private readonly Dictionary<Type, IWindow> _windows;
        private readonly Stack<IWindow> _history;
        
        private IWindow _currentWindow;

        public WindowFsm()
        {
            _windows = new Dictionary<Type, IWindow>();
            _history = new Stack<IWindow>();
        }

        public void Set<TView>() 
            where TView : class, IView
        {
            if(_windows.ContainsKey(typeof(TView))) return;
            
            var window =  new Window(typeof(TView));
            window.Opened += OnOpened;
            window.Closed += OnClosed;
            _windows.Add(typeof(TView), window);
        }

        public void CleanUp()
        {
            foreach (IWindow window in _windows.Values)
            {
                window.Opened -= OnOpened;
                window.Closed -= OnClosed;
            }
            _windows.Clear();
        }

        public void OpenWindow(Type window, bool inHistory)
        {
            if (inHistory)
                OpenedWindow(window);
            else
                OpenedWindow(window);
        }
        
        public void OpenWindow(Type window) => 
            _windows[window]?.Open();

        public void CloseWindow(Type window)
        {
            IWindow windowClose = _windows[window];
            windowClose?.Close();
        }

        public void CloseWindow()
        {
            if (_currentWindow == null)
                return;

            _history.Pop().Close();
            _history.TryPeek(out _currentWindow);
            _currentWindow?.Open();
        }

        public void ClearHistory()
        {
            _history.Clear();
            if (_currentWindow != null) 
                _history.Push(_currentWindow);
        }
        
        private void OnOpened(Type window) => Opened?.Invoke(window);
        private void OnClosed(Type window) => Closed?.Invoke(window);
        
        private void OpenedWindow(Type window)
        {
            if (_currentWindow == _windows[window])
                return;
            _currentWindow?.Close();
            _history.Push(_windows[window]);
            _currentWindow = _history.Peek();
            _currentWindow?.Open();
        }
    }
}