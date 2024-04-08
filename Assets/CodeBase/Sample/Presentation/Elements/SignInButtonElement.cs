using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Sample.Presentation.Elements
{
    [RequireComponent(typeof(Button))]
    public class SignInButtonElement : MonoBehaviour
        // , IElement<SignInDto>
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

        // public void Set(SignInDto value)
        // {
        //     _textBtn.SetText(value.Text);
        //     Button.onClick.AddListener(value.ClickInvoke);
        // }
    } 
}