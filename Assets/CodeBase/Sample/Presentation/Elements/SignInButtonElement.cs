using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sample.Presentation.Elements
{
    [RequireComponent(typeof(Button))]
    public class SignInButtonElement : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textBtn;

        private Button _button;

        private Button Button
        {
            get
            {
                if (_button == null)
                    TryGetComponent(out _button);
                return _button;
            }
        }
    } 
}