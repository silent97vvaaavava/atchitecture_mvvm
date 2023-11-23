using System;
using System.Collections.Generic;
using CodeBase.StaticData;

namespace CodeBase.Presentation
{
    public abstract class WindowFsmBase : IWindowFsm
    {
        public event Action<UiWindow> Opened;
        public event Action<UiWindow> Closed;

        private readonly Dictionary<UiWindow, IWindow> _windows;
        private readonly Stack<IWindow> _stack;
        
        private IWindow _currentWindow;

        public UiWindow CurrentWindow { get; }
        public virtual bool IsOpenWindow => _currentWindow != null;

        protected WindowFsmBase()
        {
            _stack = new Stack<IWindow>();
            
            _windows = ResolveWindows();

            foreach (IWindow window in _windows.Values)
            {
                window.Opened += OnOpened;
                window.Closed += OnClosed;
            }
        }
        
        public virtual void OpenWindow(UiWindow window)
        {
            if(_currentWindow == _windows[window])
                return;
            
            _currentWindow?.Close();
            _stack.Push(_windows[window]);
            _currentWindow = _stack.Peek();
            _currentWindow?.Open();
        }

        public virtual void OpenOneWindow(UiWindow window) // ToDo: подумать как обыграть момент с алертами (pop-up)
        {
            _windows[window]?.Open();
        }

        public virtual void CloseWindow(UiWindow window)
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
        
        protected virtual void OnOpened(UiWindow window) => Opened?.Invoke(window);
        protected virtual void OnClosed(UiWindow window) => Closed?.Invoke(window);

        protected virtual Dictionary<UiWindow, IWindow> ResolveWindows() =>
            new()
            {
                [UiWindow.Loader] = new Window(UiWindow.Loader),
                [UiWindow.Menu] = new Window(UiWindow.Menu),
                // etc.
            };
    }
}