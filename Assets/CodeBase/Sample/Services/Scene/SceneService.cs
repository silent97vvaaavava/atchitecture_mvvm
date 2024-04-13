using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sample.Services.Scene
{
    public class SceneService
    {
        private CancellationTokenSource _cts;
        
        public SceneService()
        {
        }

        public bool IsCurrentScene(int scene)
        {
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
            return SceneManager.GetActiveScene().buildIndex == scene;
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
        
        public async UniTask OnLoadSceneAsync(int sceneIndex)
        {
            if (_cts == null)
            {
                _cts = new CancellationTokenSource();
                try
                {
                    await LoadingSceneAsync(sceneIndex, _cts.Token);
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
                UpdateProgress(asyncOperation.progress);
                if (token.IsCancellationRequested)
                    return;

                if (asyncOperation.progress >= 0.9f)
                    break;
            }

            await UniTask.Delay(1500, cancellationToken: token);

            asyncOperation.allowSceneActivation = true;
            UpdateProgress(asyncOperation.progress);
            _cts.Cancel();
            token.ThrowIfCancellationRequested();
            if (token.IsCancellationRequested)
                return;
        }
        
        private async Task LoadingSceneAsync(int sceneIndex, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            if (token.IsCancellationRequested)
                return;
            
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
            asyncOperation.allowSceneActivation = false;
            
            while (true)
            {
                token.ThrowIfCancellationRequested();
                UpdateProgress(asyncOperation.progress);
                if (token.IsCancellationRequested)
                    return;

                if (asyncOperation.progress >= 0.9f)
                    break;
            }

            await UniTask.Delay(1500, cancellationToken: token);

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
        }
    }
}