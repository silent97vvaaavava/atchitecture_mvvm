using System.Collections;

namespace Core.Infrastructure.GameFsm.States
{
    public interface IState : IExitableState
    {
        void Enter();

        IEnumerator Execute();

        void AddLink(ILink link);
        void RemoveLink(ILink link);
        void RemoveAllLinks();

        bool ValidateLinks(out IState nextState);
        void EnableLinks();
        void DisableLinks();
    }
}