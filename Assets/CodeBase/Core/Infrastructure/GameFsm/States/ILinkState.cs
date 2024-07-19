using System.Collections;

namespace Core.Infrastructure.GameFsm.States
{
    public interface ILinkState : IExitableState
    {
        void Enter();

        IEnumerator Execute();

        void AddLink(ILink link);
        void RemoveLink(ILink link);
        void RemoveAllLinks();

        bool ValidateLinks(out ILinkState nextState);
        void EnableLinks();
        void DisableLinks();
    }
}