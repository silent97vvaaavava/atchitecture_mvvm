using Core.Infrastructure.Composition;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Core.Samples.MVP.Infrastructure
{
    public class CompositionRoot : SceneCompositionRoot
    {
        public override UniTask Initialize(DiContainer diContainer)
        {
            
            return default;
        }
    }
}