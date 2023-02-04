using UnityEngine;

namespace DefaultNamespace
{
    public class InteractableForwarder : BaseInteractable
    {

        public GameObject objectToForward;

        private BaseInteractable forwardInteractable;

        void Start()
        {
            forwardInteractable = objectToForward.GetComponent<BaseInteractable>();
        }

        public override void interact()
        {
            forwardInteractable.interact();
        }
    }
}