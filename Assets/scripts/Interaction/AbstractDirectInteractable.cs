using UnityEngine;

namespace DefaultNamespace
{
    public abstract class AbstractDirectInteractable: MonoBehaviour, InteractionEvent, InteractionSinkEvent
    {
        public void InteractMessage()
        {
            Debug.Log("direct interaction");
            this.ConsumeInteraction();
        }

        public abstract void ConsumeInteraction();
    }
}