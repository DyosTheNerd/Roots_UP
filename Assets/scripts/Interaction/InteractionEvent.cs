using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public interface InteractionEvent : IEventSystemHandler
    {

        void InteractMessage();

    }
}