using System.Threading.Tasks;
using UnityEngine;

namespace Core.Infrastructure.AssetManager
{
    public interface IAssetProvider
    {
        void Initialize();
        Task<T> Load<T>(string address) where T : class;
        Task<GameObject> Instantiate(string address);
        void CleanUp();
    }
}