using UnityEngine;

namespace DefaultNamespace
{
    public abstract class AbstractDirectInteractable: MonoBehaviour, InteractionEvent, InteractionSinkEvent
    {
        public void InteractMessage()
        {
            ConsumeInteraction();
        }

        public abstract void ConsumeInteraction();

        public void StopInteractMessage()
        {
            //
        }
    }
}