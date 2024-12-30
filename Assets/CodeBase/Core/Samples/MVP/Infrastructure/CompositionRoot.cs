using Core.Extensionst;
using Core.Infrastructure.Composition;
using Core.Samples.MVP.Presentation.Presenters;
using Core.Samples.MVP.Presentation.Views;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Core.Samples.MVP.Infrastructure
{
    public class CompositionRoot : SceneCompositionRoot
    {
        [SerializeField] private SceneContext _sceneContext;
        
        private DiContainer _sceneContainer;
        
        public override UniTask Initialize(DiContainer diContainer)
        {
            _sceneContext.Run();
            _sceneContainer = _sceneContext.Container;

            _sceneContainer
                .ConstructView<MenuView, MenuPresenter>()
                .ConstructView<SettingsView, SettingsPresenter>();
            
            return default;
        }
    }
}