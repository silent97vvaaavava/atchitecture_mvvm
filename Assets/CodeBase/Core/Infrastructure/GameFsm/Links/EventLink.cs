using Core.Infrastructure.EventSystem;
using Core.Infrastructure.GameFsm.States;

namespace Core.Infrastructure.GameFsm
{
    public class EventLink : ILink, IGameEventListener
    {
        private ILinkState m_NextState;
        private AbstractGameEvent m_GameEvent;
        private bool m_EventRaised;

        public EventLink(ILinkState nextState, AbstractGameEvent gameEvent)
        {
            m_NextState = nextState;
            m_GameEvent = gameEvent;
        }

        public bool Validate(out ILinkState nextState)
        {
            nextState = null;
            bool result = false;
            
            if (m_EventRaised)
            {
                nextState = m_NextState;
                result = true;
            }
            
            return result;
        }
        
        public void OnEventRaised()
        {
            m_EventRaised = true;
        }

        public void Enable()
        {
            m_GameEvent.AddListener(this);
            m_EventRaised = false;
        }
        
        public void Disable()
        {
            m_GameEvent.RemoveListener(this);
            m_EventRaised = false;
        }
    }
}