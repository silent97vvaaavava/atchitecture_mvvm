using System.Threading.Tasks;

namespace Core.Infrastructure.GameFsm.States
{
    public interface IState : IExitableState
    {
        void OnEnter();
    }
    
    public interface IAsyncState : IExitableState
    {
        Task OnEnterAsync();
    }

    public interface IPayloadedState<TPayload> : IExitableState
    {
        void OnEnter(TPayload payload);
    }
}