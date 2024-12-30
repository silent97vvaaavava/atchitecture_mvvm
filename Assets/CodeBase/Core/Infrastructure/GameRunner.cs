using UnityEngine;
using Zenject;

namespace Core.Infrastructure
{
    /// <summary>
    /// Enter point
    /// </summary>
    public class GameRunner : MonoBehaviour
    {
        [Inject]
        public void Construct(DiContainer diContainer)
        {
            if (FindObjectOfType<GameRoot>() != null)
                return;

            Application.targetFrameRate = 120;

            Instantiate(diContainer.InstantiateComponentOnNewGameObject<GameRoot>());
        }
    }
}