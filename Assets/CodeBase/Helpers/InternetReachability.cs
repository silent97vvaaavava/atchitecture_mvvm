using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

namespace CodeBase.Helpers
{
    public class InternetReachability : IInternetReachability
    {
        private const string URL =
            "https://console.firebase.google.com/u/0/project/star-puzzles/database/star-puzzles-default-rtdb/data/~2F";

        public ReactiveProperty<bool> IsConnected { get; private set; }
        
        public AsyncReactiveProperty<bool> IsConnectedAsync { get; private set; }
        
        public InternetReachability()
        {
            IsConnected = new ReactiveProperty<bool>(false);
        }
        
        public async Task<bool> IsInternetReachabilityAsync()
        {
            bool hasInternetAccess = await CheckInternetAccess();

            IsConnected.Value = hasInternetAccess;
            if(hasInternetAccess)
            {
                Debug.Log("Internet access available");
                return true;
            }
            else
            {
                Debug.Log("No internet access");
                return false;
            }
        }
        
        private async Task<bool> CheckInternetAccess()
        {
            NetworkReachability reachability = Application.internetReachability;

            if (reachability == NetworkReachability.NotReachable)
            {
                return false;
            }
            else
            {
                UnityWebRequest request = UnityWebRequest.Get(URL);
                await request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}