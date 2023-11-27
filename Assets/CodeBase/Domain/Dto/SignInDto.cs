using System;
using UnityEngine.Events;

namespace CodeBase.Domain
{
    public class SignInDto : IDto
    {
        public string Text;
        public UnityAction ClickInvoke;

        public SignInDto(string text, UnityAction clickInvoke)
        {
            Text = text;
            ClickInvoke = clickInvoke;
        }
    }
}