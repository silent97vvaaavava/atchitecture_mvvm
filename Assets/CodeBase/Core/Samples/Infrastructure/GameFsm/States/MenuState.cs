using Core.Infrastructure;
using Core.Infrastructure.Composition;
using Core.Infrastructure.GameFsm.States;
using Core.Infrastructure.WindowsFsm;
using Core.Samples.Shared.Windows;
using Cysharp.Threading.Tasks;

namespace Core.Samples.Infrastructure.GameFsm.States
{
    public class MenuState : IState
    {
        private const string Scene = "MainScene";
        private readonly SceneLoader _sceneLoader;
        private readonly SceneInitializer _sceneInitializer;
        private readonly IWindowResolve _windowResolve;

        public MenuState(
            SceneLoader sceneLoader,
            SceneInitializer sceneInitializer,
            IWindowResolve windowResolve)
        {
            _sceneLoader = sceneLoader;
            _sceneInitializer = sceneInitializer;
            _windowResolve = windowResolve;
        }

        public void OnExit()
        {
            
        }

        public void OnEnter()
        {
            PreparedWindows();

            _sceneLoader.Load(Scene, OnLoaded);
        }

        private void OnLoaded()
        {
            _sceneInitializer.Initialize().Forget();
        }

        private void PreparedWindows()
        {
            _windowResolve.CleanUp();

            _windowResolve.Set<Menu>();
            _windowResolve.Set<Settings>();
        }
    }
}