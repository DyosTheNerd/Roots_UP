using DefaultNamespace;
using DefaultNamespace.Player;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int acceleration = 100;
    public int maxspeed = 30;
    public float jumppower = 20;
    public float gravityscale;
    public float jumptimer = .4f;
    public float climbspeed = 13;

    bool facingright = false;
    bool isGrounded = false;
    Rigidbody2D rb;
    BoxCollider2D mainCollider;
    CapsuleCollider2D capsuleCollider;
    SpriteRenderer spriteRenderer;

    private const float _gravityscale = 2;

    public Animator animator;


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
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.gravityScale = gravityscale;


        _playerStatus = this.gameObject.GetComponent<PlayerStatus>();
    }

    int movedirection = 0;
    bool jumpdebounce = false;
    float timeelapsed = 0;
    float sincejump = 0;
    bool jumped = false;

    private bool canClimb = false;
    private bool isClimbing = false;
    
    // Update is called once per frame
    void Update()
    {
        if (!_playerStatus.CanMove)
        {
            //return;
        }

        //transform.localScale = new Vector3(facingright ? 1 : -1, 1, 1);
        movedirection = 0;
        isClimbing = false;
        gravityscale = _gravityscale;
        if (_playerStatus.isDead == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                movedirection += 1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                movedirection -= 1;
            }

            if (movedirection != 0)
            {
                facingright = movedirection == 1 ? true : false;
                spriteRenderer.flipX = facingright;
            }

            if (Input.GetKey(KeyCode.W) && isGrounded && !jumpdebounce && !canClimb)
            {
                //ExecuteEvents.Execute<PlayerActionMessages>(gameObject, null, (x, y) => x.OnPlayerJumped());
                jumpdebounce = true;
                rb.velocity = new Vector2(rb.velocity.x, jumppower);
                //rb.AddForce(new Vector2(0, jumppower));
                isGrounded = false;
                jumped = true;
            }
            if (Input.GetKey(KeyCode.W) && canClimb)
            {
                isClimbing = true;
            }
            if (jumped)
            {
                sincejump += Time.deltaTime;
            }
            if (!Input.GetKey(KeyCode.W))
            {
                sincejump = 0;
            }
            
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


            if (isGrounded == false)
            {
                animator.SetBool("jumped", true);
            }
            else
                {
                animator.SetBool("jumped", false);
            }

            animator.SetInteger("run", movedirection);
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

        if (isClimbing)
        {
            //ExecuteEvents.Execute<PlayerActionMessages>(gameObject, null, (x, y) => x.OnPlayerClimbing());
            rb.velocity = new Vector2(rb.velocity.x, climbspeed); 
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
        canClimb = false;
        if (mainCollider.IsTouchingLayers(LayerMask.GetMask("Climbable")))
        {
            //Debug.DrawLine(groundCheckPos, new Vector3(), Color.blue);
            canClimb = true;
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
        //Debug.DrawLine(bottomleft, bottomleft + new Vector3(0, mainCollider.size.y, 0), isGrounded ? Color.green : Color.red);
        //Debug.DrawLine(bottomleft, bottomleft + new Vector3(mainCollider.size.x, 0, 0), isGrounded ? Color.green : Color.red);
    }
}
