using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerUseInteractionSystem : MonoBehaviour
{

    private bool isInteracting = false;

    public Animator animator;


    private void OnCollisionStay2D(Collision2D other)
    {
        if (isInteracting)
        {
            Debug.Log("interating");
            ExecuteEvents.Execute<InteractionEvent>(other.gameObject, null, (x, y) => x.InteractMessage());
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            isInteracting = true;

            animator.SetBool("do", true);
        }

        else
        {
            isInteracting = false;
            animator.SetBool("do", false);
        }
    }
}
