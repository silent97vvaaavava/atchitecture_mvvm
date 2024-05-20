using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Training.Startup
{
    public class SceneLoader
    {
        public async UniTask LoadScene(string sceneName, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == sceneName) return;
            
            var waitNextScene = SceneManager.LoadSceneAsync(sceneName);
            while (!waitNextScene.isDone) await UniTask.Yield();
            onLoaded?.Invoke();
        }
    }
}