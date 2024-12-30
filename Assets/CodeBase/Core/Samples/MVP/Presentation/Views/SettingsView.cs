using Core.MVP.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Samples.MVP.Presentation.Views
{
    public class SettingsView : CanvasGroupView
    {
        [field: SerializeField] public Button CloseButton { get; private set; }
    }
}