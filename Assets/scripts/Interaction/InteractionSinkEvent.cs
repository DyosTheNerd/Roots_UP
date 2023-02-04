using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public interface InteractionSinkEvent: IEventSystemHandler
    {
        void ConsumeInteraction();
    }
}