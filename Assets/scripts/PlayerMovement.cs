using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int speed = 16;
    public float jumppower = 5;
    public int gravityscale = 1;
    public float jumptimer = .5f;

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
    bool jumpdebounce = false;
    float timeelapsed = 0;
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
        if (Input.GetKey(KeyCode.W) && isGrounded && !jumpdebounce)
        {
            jumpdebounce = true;
            rb.velocity = new Vector2(rb.velocity.x, jumppower);
            //rb.AddForce(new Vector2(0, jumppower));
            isGrounded = false;
        }
        timeelapsed += Time.deltaTime;
        if (timeelapsed >= jumptimer)
        {
            jumpdebounce = false;
            timeelapsed = 0;
        }

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movedirection * speed,rb.velocity.y);

        Bounds colliderbounds = mainCollider.bounds;
        float colliderradius = mainCollider.size.x;
        Vector3 groundCheckPos = colliderbounds.min + new Vector3(mainCollider.size.x/2, mainCollider.size.y/2, 0);
        // Check if player is groundeded
        //Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderradius);
        Collider2D colliders = Physics2D.OverlapCircle(groundCheckPos, colliderradius, LayerMask.GetMask("Default"));
        // Check if any of the overlapping colliders are not player collider, if so set isGrounded to true
        isGrounded = false;
        if (colliders.IsTouchingLayers())
        {
            isGrounded = true;
        }

        /*if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    break;
                }
            }
        }*/

        // Simple debug
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderradius, 0), isGrounded ? Color.green : Color.red);
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderradius, 0, 0), isGrounded ? Color.green : Color.red);
    }
}
