using CodeBase.Helpers;
using CodeBase.Services;
using Cysharp.Threading.Tasks;
// using GooglePlayGames;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class InitializeState : BaseState
    {
        private readonly InternetReachability _internetReachability;
        
        private readonly LoaderScene _loaderScene;
        private readonly ILoadingCurtain _curtain;
        private readonly DatabaseService _databaseService;

        // private readonly AuthorizationSocialService _authSocial;

        public InitializeState(
            IGameStateMachine gameStateMachine,
            InternetReachability internetReachability,
            ILoadingCurtain curtain,
            DatabaseService databaseService
            ) : base(gameStateMachine)
        {
            _internetReachability = internetReachability;
            _loaderScene = new LoaderScene(curtain);
            _curtain = curtain;
            _databaseService = databaseService;
            // _authSocial = new AuthorizationSocialService(internetReachability, databaseService);
        }
        
        
        public override async void Enter()
        { 
            // PlayGamesPlatform.Activate();
            // await _authSocial.OnStart(_curtain.Progress);
            await UniTask.SwitchToMainThread();
            await _loaderScene.OnLoadSceneAsync("Gameplay").ContinueWith(Exit);
        }

        public override void Exit()
        {
            Debug.LogWarning($"is gamestateMachine null {_gameStateMachine == null}");
            _gameStateMachine?.Enter<LoaderState>();
        }
    }
}