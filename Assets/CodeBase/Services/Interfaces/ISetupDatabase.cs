using System;
using System.Threading.Tasks;

// using Firebase.Auth;

namespace CodeBase.Services.Interfaces
{
    public interface ISetupDatabase
    {
        // void OnSetup(AuthResult user);
    }

    public interface IInitializeDatabase
    {
        Task InitializeAsync(IProgress<int> progress = null);
    }
}