using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int speed = 30;
    public float jumppower = 12;
    public int gravityscale = 2;
    public float jumptimer = .5f;

    bool isGrounded = false;
    Rigidbody2D rb;
    BoxCollider2D mainCollider;
    CapsuleCollider2D capsuleCollider;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        mainCollider = GetComponent<BoxCollider2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
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
        rb.AddForce(new Vector2(movedirection * speed,rb.velocity.y));
        //rb.velocity = new Vector2(movedirection * speed,rb.velocity.y);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -30, 30), rb.velocity.y);


        Vector3 groundCheckPos = mainCollider.transform.position + new Vector3(mainCollider.offset.x, mainCollider.offset.y, 0);
        // Check if player is groundeded
        //Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderradius);
        //Collider2D colliders = Physics2D.OverlapBox(mainCollider.transform.position, mainCollider.size, 0,  LayerMask.GetMask("Default"));
        
        // Check if any of the overlapping colliders are not player collider, if so set isGrounded to true
        isGrounded = false;
        if (mainCollider.IsTouchingLayers(LayerMask.GetMask("Default")))
        {
            //Debug.DrawLine(groundCheckPos, new Vector3(), Color.blue);
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

        Vector3 bottomleft = groundCheckPos - new Vector3(mainCollider.size.x, mainCollider.size.y, 0)/2;
        // Simple debug
        Debug.DrawLine(bottomleft, bottomleft + new Vector3(0, mainCollider.size.y, 0), isGrounded ? Color.green : Color.red);
        Debug.DrawLine(bottomleft, bottomleft + new Vector3(mainCollider.size.x, 0, 0), isGrounded ? Color.green : Color.red);
    }
}
