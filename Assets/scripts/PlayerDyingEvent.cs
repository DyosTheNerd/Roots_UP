using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public interface PlayerDyingEvent : IEventSystemHandler
    {
        void DyingMessage(string reason);
    }
}