using System.Threading.Tasks;

namespace CodeBase.Helpers
{
    public interface IInternetReachability
    {
        Task<bool> IsInternetReachabilityAsync();
    }
}