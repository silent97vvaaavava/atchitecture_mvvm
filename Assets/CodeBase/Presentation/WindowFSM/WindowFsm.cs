using System;
using System.Collections.Generic;
using CodeBase.Presentation.Views;
using CodeBase.StaticData;

namespace CodeBase.Presentation
{
    public class WindowFsm : IWindowFsm
    {
        public event Action<Type> Opened;
        public event Action<Type> Closed;

        private readonly Dictionary<Type, IWindow> _windows;
        private readonly Stack<IWindow> _stack;
        
        private IWindow _currentWindow;

        public Type CurrentWindow { get; }
        public virtual bool IsOpenWindow => _currentWindow != null;

        protected WindowFsm()
        {
            _stack = new Stack<IWindow>();
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
        
        public virtual void OpenWindow(Type window)
        {
            if(_currentWindow == _windows[window])
                return;
            
            _currentWindow?.Close();
            _stack.Push(_windows[window]);
            _currentWindow = _stack.Peek();
            _currentWindow?.Open();
        }

        public virtual void OpenOneWindow(Type window) 
        {
            _windows[window]?.Open();
        }

        public virtual void CloseWindow(Type window)
        {
            var windowClose = _windows[window];
            windowClose?.Close();
        }

        public virtual void CloseCurrentWindow()
        {
            if (_currentWindow == null)
                return;

            _stack.Pop().Close();
            _stack.TryPeek(out _currentWindow);
            _currentWindow?.Open();
        }

        public virtual void ClearHistory()
        {
            _stack.Clear();
            if (_currentWindow != null) 
                _stack.Push(_currentWindow);
        }
        
        protected virtual void OnOpened(Type window) => Opened?.Invoke(window);
        protected virtual void OnClosed(Type window) => Closed?.Invoke(window);
    }
}