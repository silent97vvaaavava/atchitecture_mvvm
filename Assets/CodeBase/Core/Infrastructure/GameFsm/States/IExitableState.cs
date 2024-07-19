namespace Core.Infrastructure.GameFsm.States
{
    public interface IExitableState
    {
        void OnExit();
    }
}