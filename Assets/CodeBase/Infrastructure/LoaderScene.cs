using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure
{
    public class LoaderScene
    {
        private ILoadingCurtain _curtain;

        private CancellationTokenSource _cts;

        public LoaderScene(ILoadingCurtain curtain)
        {
            _curtain = curtain;
        }

        public async UniTask OnLoadSceneAsync(string sceneName)
        {
            if (_cts == null)
            {
                _cts = new CancellationTokenSource();
                try
                {
                    await LoadingSceneAsync(sceneName, _cts.Token);
                }
                catch (OperationCanceledException exp)
                {
                    if (exp.CancellationToken == _cts.Token)
                    {
                        Debug.LogWarning("Task cancelled");
                    }
                }
                finally
                {
                    _cts.Cancel();
                    _cts = null;
                }
            }
            else
            {
                _cts.Cancel();
                _cts = null;
            }


        }

        private async Task LoadingSceneAsync(string sceneName, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            if (token.IsCancellationRequested)
                return;
            
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            asyncOperation.allowSceneActivation = false;
            
            while (true)
            {
                token.ThrowIfCancellationRequested();
                Debug.LogWarning($"result progress scene {asyncOperation.progress}");
                UpdateProgress(asyncOperation.progress);

                if (token.IsCancellationRequested)
                    return;

                if (asyncOperation.progress >= 0.9f)
                    break;
            }

            await UniTask.Delay(1500);

            asyncOperation.allowSceneActivation = true;
            UpdateProgress(asyncOperation.progress);
            _cts.Cancel();
            token.ThrowIfCancellationRequested();
            if (token.IsCancellationRequested)
                return;
        }

        private void UpdateProgress(float progress)
        {
            float percentage = progress * 100;
            int percentageInt = (int)Math.Round(percentage, 0);
            _curtain.UpdateProgress(percentageInt);
        }
    }
}