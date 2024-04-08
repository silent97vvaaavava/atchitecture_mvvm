using System;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Sample.Presentation.Elements
{
    [RequireComponent(typeof(Toggle))]
    public class ToggleElement : MonoBehaviour
    {
        public Action<bool> Callback;
        
        private Toggle _toggle;
            
        public Toggle ToggleComponent
        {
            get
            {
                if (_toggle == null)
                    TryGetComponent(out _toggle);
                return _toggle;
            }
        }

        private Graphic Graphic => 
            _toggle != null ? _toggle.graphic : null;


        private void OnValidate()
        {
            ToggleComponent.onValueChanged.AddListener(OnClick);
        }

        private void Awake()
        {
            ToggleComponent.onValueChanged.AddListener(OnClick);
        }

        private void OnClick(bool isOn)
        {
            Graphic.color = !isOn ? Color.clear : Color.white;
            Callback?.Invoke(isOn);
        }
    }
}