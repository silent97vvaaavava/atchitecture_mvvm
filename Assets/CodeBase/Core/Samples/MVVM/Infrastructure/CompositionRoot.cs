using Core.Infrastructure.Composition;
using Core.Samples.MVVM.Presentation.Views;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Core.Samples.MVVM.Infrastructure
{
    public class CompositionRoot : SceneCompositionRoot
    {
        [SerializeField] private MenuView _menuView;
        
        public override UniTask Initialize(DiContainer diContainer)
        {
            
            
            return default;
        }
    }
}