using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEditor.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int acceleration = 100;
    public int maxspeed = 30;
    public float jumppower = 15;
    public float gravityscale;
    public float jumptimer = .4f;

    bool facingright = false;
    bool isGrounded = false;
    Rigidbody2D rb;
    BoxCollider2D mainCollider;
    CapsuleCollider2D capsuleCollider;

    private const float _gravityscale = 2;


    private PlayerStatus _playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        facingright = transform.localScale.x > 0 ? true : false;
        gravityscale = _gravityscale;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        mainCollider = GetComponent<BoxCollider2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        rb.gravityScale = gravityscale;


        _playerStatus = this.gameObject.GetComponent<PlayerStatus>();
    }

    int movedirection = 0;
    bool jumpdebounce = false;
    float timeelapsed = 0;
    float sincejump = 0;
    bool jumped = false;
    // Update is called once per frame
    void Update()
    {
        if (!_playerStatus.CanMove)
        {
            //return;
        }

        transform.localScale = new Vector3(facingright ? 1 : -1, 1, 1);
        
        movedirection = 0;
        if (Input.GetKey(KeyCode.D))
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
            jumped = true;
        }
        if (jumped)
        {
            sincejump += Time.deltaTime;
        }
        if (!Input.GetKey(KeyCode.W))
        {
            sincejump = 0;
        }
        gravityscale = _gravityscale;
        if (Input.GetKey(KeyCode.S))
        {
            gravityscale = 10;
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
        float dt = Time.fixedDeltaTime;
        rb.gravityScale = gravityscale;
        //rb.velocity = new Vector2(movedirection * speed,rb.velocity.y);
        rb.AddForce(new Vector2(movedirection * acceleration * dt, 0), ForceMode2D.Impulse);
        rb.AddForce(new Vector2((rb.velocity.x * -5f * dt), 0.0f), ForceMode2D.Impulse);
        if (rb.velocity.x > maxspeed)
        {
            rb.AddForce(new Vector2((maxspeed - rb.velocity.x) * rb.mass, 0), ForceMode2D.Impulse);
        }
        if (rb.velocity.x < -maxspeed)
        {
            rb.AddForce(new Vector2((-maxspeed - rb.velocity.x) * rb.mass, 0), ForceMode2D.Impulse);
        }
        if (gravityscale > _gravityscale && rb.velocity.y > 0)
        {
            rb.AddForce(new Vector2(0, -rb.velocity.y), ForceMode2D.Impulse);
        }
        if (jumped && Input.GetKey(KeyCode.W) && sincejump < .05)
        {
            rb.AddForce(new Vector2(0, 10 * dt), ForceMode2D.Impulse);
        }
        //rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x * 0.9f, -maxspeed, maxspeed), rb.velocity.y);


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
            jumped = false;
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
        //Debug.LogFormat("The current speed is {0}", rb.velocity.x);
        Debug.DrawLine(transform.position, transform.position + new Vector3(rb.velocity.x, rb.velocity.y, 0)/10, Color.blue);
        Debug.DrawLine(bottomleft, bottomleft + new Vector3(0, mainCollider.size.y, 0), isGrounded ? Color.green : Color.red);
        Debug.DrawLine(bottomleft, bottomleft + new Vector3(mainCollider.size.x, 0, 0), isGrounded ? Color.green : Color.red);
    }

}
