using System;
using System.Threading.Tasks;

namespace CodeBase.Services.Interfaces
{
    /// <summary>
    /// For Authorization in remote services 
    /// </summary>
    public interface IAuthorization
    {
        Task SignInAsync(IProgress<int> progress = null);
    }
}