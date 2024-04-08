using CodeBase.Sample.Presentation.Models;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Sample.Presentation.Views
{
    public class InternetReachabilityView : MonoBehaviour
    {
        private InternetReachabilityModel _model;

        [field: SerializeField] public TMP_Text MessageText { get; private set; }
        [field: SerializeField] public Button ResetButton { get; private set; }

        [Inject]
        private void Construct(InternetReachabilityModel model)
        {
            _model = model;
        }

        private void Start()
        {
            ResetButton
                .OnClickAsObservable()
                .Subscribe(async x =>
                {
                    var res = await _model.IsInternetReachabilityAsync();
                });
            
            _model
                .IsConnected
                .Subscribe(x =>
                {
                    gameObject.SetActive(!x);
                });
        }
    }
}