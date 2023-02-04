using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int speed = 16;
    public float jumppower = 50;
    public int gravityscale = 1;

    bool isGrounded = false;
    Rigidbody2D rb;
    CapsuleCollider2D mainCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        mainCollider = GetComponent<CapsuleCollider2D>();
        rb.gravityScale = gravityscale;
    }

    int movedirection = 0;
    // Update is called once per frame
    void Update()
    {
        bool jump = false;
        movedirection = 0;
        if (Input.GetKey(KeyCode.D) )
        {
            movedirection += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movedirection -= 1;
        }
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumppower);
        }
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movedirection * speed,rb.velocity.y);

        isGrounded = false;
        Bounds colliderbounds = mainCollider.bounds;
        float colliderradius = mainCollider.size.x;
        Vector3 groundCheckPos = colliderbounds.min + new Vector3(mainCollider.size.x + .1f, mainCollider.size.y + .1f, 0);
        // Check if player is groundeded
        
    }
}
