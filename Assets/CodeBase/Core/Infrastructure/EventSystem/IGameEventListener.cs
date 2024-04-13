namespace Core.Infrastructure.EventSystem
{
    public interface IGameEventListener
    {
        void OnEventRaised();
    }
}