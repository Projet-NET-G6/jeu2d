using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovements : MonoBehaviour
{
    private float moveSpeed = 6f;
    public double sprintSpeed = 1f;
    public float wallSlidingSpeed = 0.75f;

    private float wallJumpX = 2f;
    private float wallJumpY = 1.3f;
    private float JumpForce = 7f;


    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;




    //data necessaire au GrounCheck
    public Transform groundCheck;
    public float groundCheckRadius = 0.35f;
    //data necessaire au FrontCheck
    public Transform frontCheck;
    public float frontCheckRadius = 0.25f;

    public LayerMask whatIsGround;

    public bool isWallSliding = false;
    public bool isGrounded = false;
    public bool isWalled = false;
    public bool isSprinting = false;
    public bool flip = false;

    //Creation des fields components
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D playerCollider;




    public static NewPlayerMovements instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'une instance de PlayerMouvement dans la scène");
            return;
        }

        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Activation du Sprint
        if (Input.GetKey("left shift") || Input.GetKey("right shift"))
        {
            isSprinting = true;
            sprintSpeed = 1.5f;
        }
        if (Input.GetKeyUp("left shift") || Input.GetKeyUp("right shift"))
        {
            isSprinting = false;
            sprintSpeed = 1f;
        }
        //Animation fall ou jump
        if(isGrounded == false)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        //Animation WallSliding
        if (isGrounded == false && isWalled == true)
        {
            isWallSliding = true;
            animator.SetBool("IsSliding", true);
        }
        else
        {
            isWallSliding = false;
            animator.SetBool("IsSliding", false);
        }

        //Animation Marche et Saut
        float characterVelocityX = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("XSpeed", characterVelocityX);
        float characterVelocityY = rb.velocity.y;
        animator.SetFloat("YSpeed", characterVelocityY);

        //inversion de l'image du personnage
        Flip(rb.velocity.x);
    }

    void FixedUpdate()
    {
        //interaction entre les gameobject grounCheck/frontCheck et l'environnement: s'il y a superposition de deux zone retourne true
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        isWalled = Physics2D.OverlapCircle(frontCheck.position, frontCheckRadius, whatIsGround);
        
        //Deplacement Gauche Droite
        if (Input.GetKey("q") || Input.GetKey("left"))
        {
            rb.velocity = new Vector2((float)(-moveSpeed * sprintSpeed), rb.velocity.y);
            flip = true;
        }
        else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.velocity = new Vector2((float)(moveSpeed * sprintSpeed), rb.velocity.y);
            flip = false;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        //Vitesse du WallSliding
        if (isWallSliding == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        //Jump 
        if ((Input.GetKey("space") && isGrounded == true))
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

        //WallJump
        if (Input.GetKey("space") && isWallSliding == true)
        {
            if (flip == false)
            {
                rb.velocity = new Vector2(-JumpForce * wallJumpX, JumpForce * wallJumpY);
            }
            else if (flip == true)
            {
                rb.velocity = new Vector2(JumpForce * wallJumpX, JumpForce * wallJumpY);
            }
        }
        
        if(betterJump)
        {
            if(rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }

            if (rb.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }

        }
    }
    //Inverse l'image en fonction du sens du déplacement
    void Flip(float _velocity)
    {
        if (_velocity > 0.2f)
        {
            transform.localScale = Vector3.one;
        }
        else if (_velocity < -0.2f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); 
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Montre la zone que groundCheck va couvrir
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        //Montre la zone que frontCheck va couvrir
        Gizmos.DrawWireSphere(frontCheck.position, frontCheckRadius);
    }
}
