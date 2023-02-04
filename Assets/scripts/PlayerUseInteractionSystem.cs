using System;
using DefaultNamespace;
using UnityEngine;

public class PlayerUseInteractionSystem : MonoBehaviour
{

    private bool isInteracting = false;


    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("collides");
        if (isInteracting)
        {
            other.gameObject.GetComponent<BaseInteractable>().interact();
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
            Debug.Log("interacting");
        }

        else
        {
            isInteracting = false;
        }
    }
}
