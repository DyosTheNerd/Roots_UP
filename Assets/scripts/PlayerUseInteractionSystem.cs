using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerUseInteractionSystem : MonoBehaviour
{

    private bool isInteracting = false;

    private GameObject interationObject;
    
    public Animator animator;

    void OnCollisionStay2D(Collision2D other)
    {
        if (isInteracting && interationObject == null)
        {
            
            startInteraction(other);
        }
    }

    
    void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("collision exit");
        if (other.gameObject == interationObject)
        {
            Debug.Log("ending interaction");
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
            interationObject = null;
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
