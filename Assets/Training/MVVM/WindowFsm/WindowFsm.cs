using System;
using System.Collections.Generic;
using Core.MVVM.View;
using Core.MVVM.WindowFsm;
using UnityEngine;

namespace Training.MVVM.WindowFsm
{
    public class WindowFsm : IWindowFsm, IWindowResolve
    {
        public int fsmNumber;

        public event Action<Type> Opened;
        public event Action<Type> Closed;

        private readonly Dictionary<Type, IWindow> _windows;    
        private readonly Stack<IWindow> _windowHistory;

        private IWindow _currentWindow;
        public Type CurrentWindow { get; }

        public bool IsOpenWindow => _currentWindow != null;  // Is it an opend Window

        protected WindowFsm()
        {
            _windows = new Dictionary<Type, IWindow>();
            _windowHistory = new Stack<IWindow>();
        }

        public void Set<TView>() where TView : class, IView
        {
            Debug.Log("Set view to the window fsm " + typeof(TView).Name);
            if (_windows.ContainsKey(typeof(TView))) return;
            var window = new Window(typeof(TView));
            window.Opened += OnOpened;
            window.Closed += OnClosed;
            _windows.Add(typeof(TView), window);
        }

        private string DebugDictionary(Dictionary<Type, IWindow> windows)
        {
            string message = "";
            foreach (var key in windows.Keys)
            {
                message += key.ToString();
                message += " "; 
            }
            return message;
        }
        public void OpenWindow(Type windowType)
        {
            Debug.Log($"Открываем окно типa: {windowType.Name}. В списке windowFsm: {DebugDictionary(_windows)}. Номер стейт машины - {fsmNumber}");

            if (_currentWindow == _windows[windowType])
                return;
            //Debug.Log($"Open window{windowType.Name}");

            _currentWindow?.Close();
            _windowHistory.Push(_windows[windowType]);
            _currentWindow = _windowHistory.Peek();
            _currentWindow?.Open();
        }

        public void OpenOneWindow(Type window)
        {
            _windows[window]?.Open();
        }

        public void CloseWindow(Type type)
        {
            _windows.TryGetValue(type, out var window);
            window?.Close();
        }
    
        public void CloseCurrentWindow()
        {
            if (_currentWindow == null) 
                return;
            
            _windowHistory.Pop().Close();
            _windowHistory.TryPeek(out _currentWindow);
            _currentWindow?.Open();
        }

        public void ClearHistory()
        {
            _windowHistory.Clear(); 
            if (_currentWindow != null) 
                _windowHistory.Push(_currentWindow);        
        }

        private void OnOpened(Type type) => Opened?.Invoke(type);
        private void OnClosed(Type type) => Closed?.Invoke(type);
    }
}
