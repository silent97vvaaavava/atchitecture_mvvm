using Core.Infrastructure.Composition;
using Core.Samples.MVVM.Presentation.ViewModels;
using Core.Samples.MVVM.Presentation.Views;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Core.Samples.MVVM.Infrastructure
{
    public class CompositionRoot : SceneCompositionRoot
    {
        [SerializeField] private SceneContext _sceneContext;
        
        [SerializeField] private MenuView _menuView;
        [SerializeField] private SettingsView _settingsView;
        
        private DiContainer _sceneContainer;
        
        public override UniTask Initialize(DiContainer diContainer)
        {
            _sceneContext.Run();
            _sceneContainer = _sceneContext.Container;

            _menuView.Construct(_sceneContainer.Resolve<MenuViewModel>());
            _settingsView.Construct(_sceneContainer.Resolve<SettingsViewModel>());
            
            return default;
        }
    }
}