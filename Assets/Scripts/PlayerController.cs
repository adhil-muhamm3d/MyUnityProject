using UnityEngine;

public class PlayerClimbAndJump : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float climbSpeed = 4f;
    public float jumpForce = 8f;

    private Rigidbody2D rb;
    private Collider2D playerCollider;

    private float horizontal;
    private float vertical;
    private bool isClimbing = false;
    private bool isOnLadder = false;
    private bool isGrounded = false;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded && !isClimbing)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Climbing logic
        if (isOnLadder)
        {
            if (Mathf.Abs(vertical) > 0.1f)
                isClimbing = true;
        }
        else
        {
            isClimbing = false;
        }
    }

    void FixedUpdate()
    {
        // Horizontal movement
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);

        // Climbing movement
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, vertical * climbSpeed);
        }
        else
        {
            rb.gravityScale = 3f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ladder"))
        {
            isOnLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ladder"))
        {
            isOnLadder = false;
        }
    }
}
