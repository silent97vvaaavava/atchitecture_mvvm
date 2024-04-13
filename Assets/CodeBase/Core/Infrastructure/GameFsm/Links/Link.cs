using Core.Infrastructure.GameFsm.States;

namespace Core.Infrastructure.GameFsm
{
    public class Link : ILink
    {
        private readonly IState m_NextState;
        
        /// <param name="nextState">the next state</param>
        public Link(IState nextState)
        {
            m_NextState = nextState;
        }

        public bool Validate(out IState nextState)
        {
            nextState = m_NextState;
            return true;
        }
    }
}