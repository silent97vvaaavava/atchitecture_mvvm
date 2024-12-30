using Core.MVP.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Samples.MVP.Presentation.Views
{
    public class MenuView : CanvasGroupView
    {
        [field: SerializeField] public Button ChangeSceneButton { get; private set; }
        [field: SerializeField] public Button SettingsButton { get; private set; }
        [field: SerializeField] public Button AnotherButton { get; private set; }
    }
}