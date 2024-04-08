using CodeBase.Core.Data.Dto;
using UnityEngine.Events;

namespace CodeBase.Sample.Data.Dto
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