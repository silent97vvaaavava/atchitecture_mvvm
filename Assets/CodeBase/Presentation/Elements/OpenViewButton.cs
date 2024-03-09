using CodeBase.Infrastructure.Providers;
using CodeBase.Presentation.Views;
using TypeReferences;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Presentation.Elements
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
        private void Construct(WindowFsmProvider provider)
        {
            _windowFsm = provider.Local;
        }
        
        private void Awake()
        {
            ButtonElement.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _windowFsm.OpenWindow(_window.Type);
        }
    }
}