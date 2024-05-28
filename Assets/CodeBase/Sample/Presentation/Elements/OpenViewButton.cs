using Core.Domain.Providers;
using Core.MVVM.View;
using Core.MVVM.Windows;
using TypeReferences;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Sample.Presentation.Elements
{
    [RequireComponent(typeof(Button))]
    public class OpenViewButton : MonoBehaviour
    {
        [SerializeField]
        [Inherits(typeof(IView), ShortName = true)]
        private TypeReference _window;
        
        private Button _button;
        private IWindowFsm _windowFsm;

        private Button ButtonElement
        {
            get
            {
                if (_button == null)
                    TryGetComponent(out _button);
                return _button;
            }
        }

        [Inject]
        private void Construct(IWindowFsmProvider provider)
        {
            _windowFsm = provider.Local;
        }
        
        private void Awake()
        {
            ButtonElement.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _windowFsm.OpenWindow(_window.Type, true);
        }
    }
}