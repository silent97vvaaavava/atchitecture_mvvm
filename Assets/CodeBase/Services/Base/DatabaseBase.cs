using System;
using System.Threading.Tasks;
using CodeBase.Helpers;

namespace CodeBase.Services.Base
{
    public abstract class DatabaseBase
    {
        protected readonly IInternetReachability _internetReachability;
        
        protected virtual string UserID { get; }
        
        protected DatabaseBase(IInternetReachability internetReachability)
        {
            _internetReachability = internetReachability;
        }

        protected abstract Task<bool> IsExistsValueAsync(IProgress<int> progress = null);
        protected abstract Task CreateUserDataAsync(IProgress<int> progress = null);
    }
}