using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerUseInteractionSystem : MonoBehaviour
{

    private bool isInteracting = false;

    private GameObject interationObject;
    
    public Animator animator;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (isInteracting)
        {
            startInteraction(other);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (isInteracting)
        {
            stopInteraction();
        }
    }

    void startInteraction(Collision2D other)
    {
        interationObject = other.gameObject;
        ExecuteEvents.Execute<InteractionEvent>(other.gameObject, null, (x, y) => x.InteractMessage());
    }

    void stopInteraction()
    {
        if (interationObject)
        {
            animator.SetBool("do", false);
            isInteracting = false;
            ExecuteEvents.Execute<InteractionEvent>(interationObject, null, (x, y) => x.StopInteractMessage());    
        }
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
           isInteracting = true;

           animator.SetBool("do", true);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            stopInteraction();
        }
    }
}
