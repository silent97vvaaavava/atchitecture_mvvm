using CodeBase.Helpers;
using CodeBase.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class StateInitialize : StateBase
    {
        private readonly InternetReachability _internetReachability;
        
        private readonly LoaderScene _loaderScene;
        private readonly ILoadingCurtain _curtain;

        public StateInitialize(
            IGameFsm gameFsm,
            InternetReachability internetReachability,
            ILoadingCurtain curtain,
            DatabaseService databaseService
            ) : base(gameFsm)
        {
            _internetReachability = internetReachability;
            _loaderScene = new LoaderScene(curtain);
            _curtain = curtain;
        }
        
        
        public override async void Enter()
        { 
            await _loaderScene.OnLoadSceneAsync("Gameplay").ContinueWith(Exit);
        }

        public override void Exit()
        {
            Debug.LogWarning($"is gamestateMachine null {GameFsm == null}");
            GameFsm?.Enter<StateLoader>();
        }
    }
}