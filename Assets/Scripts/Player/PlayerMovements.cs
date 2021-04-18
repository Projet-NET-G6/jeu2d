using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    //vitesse de déplacement du personnage
    public float moveSpeed;
    public double sprintSpeed;
    
    public float wallSlidingSpeed;

    public float JumpForce;

    public float xWallJumpForce;
    public float yWallJumpForce;

    public bool isJumping = false;
    public bool isWallJumping = false;
    public bool isWallSliding = false;
    public bool isSprinting = false;

    public bool isGrounded = false;
    public bool isWalled = false;
    
    //data necessaire au GrounCheck
    public Transform groundCheck;
    public float groundCheckRadius;
    //data necessaire au FrontCheck
    public Transform frontCheck;
    public float frontCheckRadius;

    public LayerMask whatIsGround;

    /*public bool FlipX;*/

    public static PlayerMovements instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'une instance de PlayerMouvement dans la scène");
            return;
        }

        instance = this;
    }

    //rigidbody du personnage
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D playerCollider;


    private Vector3 velocity = Vector3.zero;



    void Update()
    {

        if(Input.GetKey("left shift") || Input.GetKey("right shift"))
        {
            isSprinting = true;
        }
        if (Input.GetKeyUp("left shift") || Input.GetKeyUp("right shift"))
        {
            isSprinting = false;
        }
        //jump normal
        if (Input.GetButtonDown("Jump") && isGrounded==true)
        {
            isJumping = true;
        }
        //wall jump
        if(Input.GetButtonDown("Jump") && isGrounded==false && isWalled == true)
        {
            isWallJumping = true;
        }
        if(isGrounded == false && isWalled==true && Input.GetAxis("Horizontal") !=0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);

    }

    void FixedUpdate()
    {
        float horizontalMovement;
        //Time.deltaTime = aussi longtemps qu'on maintient la touche on avance ou pas 
        if (isSprinting == true)
        {
            horizontalMovement = Input.GetAxis("Horizontal") * ((float)(moveSpeed * sprintSpeed))* Time.deltaTime;
        }
        else
        {
            horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        }
        //Physics2D.OverlapCircle va crée un zone de collision à partir du point goundCheck et lui rajouté un radius puis verif si il ya collision dans la zone créé 
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius ,whatIsGround);

        isWalled = Physics2D.OverlapCircle(frontCheck.position, frontCheckRadius, whatIsGround);

        MovePlayer(horizontalMovement);

    }

    void MovePlayer(float _horizontalMovement)
    {
        //rb.velocity.y va lui envoyé la force sur l'axe y que l'objet a actuellement s'il en a pas il ne bouge pas en y
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping==true)
        {
            rb.AddForce(new Vector2(0f, JumpForce));
            isJumping = false;
        }
        //A AMELIORER ABSOLUMENT
        if(isWallJumping == true)
        {
            //rb.velocity = new Vector2 (xWallJumpForce, yWallJumpForce);
            if(Input.GetAxis("Horizontal") > 0)
            {
                rb.AddForce(new Vector2(-xWallJumpForce, yWallJumpForce));
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                rb.AddForce(new Vector2(xWallJumpForce, yWallJumpForce));
            }
            /*if (rb.velocity.x > 0.1)
            {
                rb.AddForce(new Vector2(-Input.GetAxis("Horizontal") * moveSpeed, JumpForce));
            }
            else if (rb.velocity.x < -0.1)
            {
                rb.AddForce(new Vector2(-Input.GetAxis("Horizontal") * moveSpeed, JumpForce));
            }*/

            /*if (spriteRenderer.flipX == false)
            {
                rb.AddForce(new Vector2(-xWallJumpForce, yWallJumpForce));
            }
            else if(spriteRenderer.flipX == true)
            {
                rb.AddForce(new Vector2(xWallJumpForce, yWallJumpForce));
            }*/
            isWallJumping = false;
        }
        //A AMELIORER
        if(isWallSliding == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
    }

    
    //si deplacement vers la gauche velocity neg dont avec ça on va flip si vitesse positive ou neg
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            transform.localScale = Vector3.one;
        }
        else if (_velocity < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        //ancienne version du flip 
        /*if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
            frontCheck.transform.localPosition = new Vector3(0.25f, frontCheck.transform.localPosition.y, frontCheck.transform.localPosition.y);

        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
            frontCheck.transform.localPosition = new Vector3(-0.25f, frontCheck.transform.localPosition.y, frontCheck.transform.localPosition.y);
        }*/
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

