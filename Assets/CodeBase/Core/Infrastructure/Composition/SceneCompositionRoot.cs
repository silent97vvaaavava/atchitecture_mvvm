using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Core.Infrastructure.Composition
{
    public abstract class SceneCompositionRoot : MonoBehaviour
    {
        public abstract UniTask Initialize(DiContainer diContainer);
    }
}