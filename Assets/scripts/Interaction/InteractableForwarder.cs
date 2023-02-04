using UnityEngine;

namespace DefaultNamespace
{
    /**
     * Forwards an interaction event to an Interactable Object
     */
    public class InteractableForwarder : MonoBehaviour, InteractionEvent
    {

        public GameObject objectToForward;

        public void InteractMessage()
        {
            
        }
    }
}