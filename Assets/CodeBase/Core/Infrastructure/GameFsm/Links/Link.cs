using Core.Infrastructure.GameFsm.States;

namespace Core.Infrastructure.GameFsm
{
    public class Link : ILink
    {
        private readonly ILinkState m_NextState;
        
        /// <param name="nextState">the next state</param>
        public Link(ILinkState nextState)
        {
            m_NextState = nextState;
        }

        public bool Validate(out ILinkState nextState)
        {
            nextState = m_NextState;
            return true;
        }
    }
}