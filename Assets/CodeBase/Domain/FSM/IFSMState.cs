namespace CodeBase.Domain.FSM
{
    public interface IFSMState
    {
        void Enter();
        void Exit();
        void Update();
        void Dispose();
    }
}