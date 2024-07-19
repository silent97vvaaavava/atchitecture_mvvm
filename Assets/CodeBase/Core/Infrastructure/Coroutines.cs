using System.Collections;
using UnityEngine;

namespace Core.Infrastructure
{
    public class Coroutines : ICoroutineRunner
    {
        public class CoroutineRunner : MonoBehaviour { }

        private CoroutineRunner _runner;
        
        public CoroutineRunner Runner
        {
            get
            {
                if (_runner == null)
                {
                    var runner = new GameObject(nameof(Coroutines), typeof(CoroutineRunner));
                    _runner = runner.GetComponent<CoroutineRunner>();
                    runner.hideFlags = HideFlags.HideAndDontSave;
                    Object.DontDestroyOnLoad(runner);
                }

                return _runner;
            }
        }

        public Coroutine StartCoroutine(IEnumerator coroutine) => 
            Runner.StartCoroutine(coroutine);

        public void StopCoroutine(ref Coroutine coroutine)
        {
            if(coroutine == null) return;
            Runner.StopCoroutine(coroutine);
            coroutine = null;
        }
    }
}