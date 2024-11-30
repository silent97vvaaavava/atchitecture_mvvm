using Core.Infrastructure.Composition;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Sample.Scripts.Infrastructure.Composition
{
    public class MainMenuCompositionRoot : SceneCompositionRoot
    {
        public override UniTask Initialize(DiContainer diContainer)
        {
            return default;
        }
    }
}