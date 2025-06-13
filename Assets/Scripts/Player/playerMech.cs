using UnityEngine;

public class playerMech : MonoBehaviour
{

    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public int HealthPoints = 5;
    public GameObject GameOver;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpforce;
    [SerializeField] private float DefaultGravity = 1;
    public Animator HeroAnimator;
    [Space(20)]
    public Transform RayOrigin;
    public LayerMask GroundLayer;

    private bool FaceRight = true;
    private bool isGround = false;

    public float RayDistance;

    public Punch punch;

    void Awake()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        PunchAttack();
    }

    void FixedUpdate()
    {
        Movement();
        RaycastHit2D hit = Physics2D.Raycast(RayOrigin.position,Vector2.down,RayDistance,GroundLayer);
        isGround = hit.collider != null;
        Color Raycolor = hit.collider != null ? Color.green : Color.red;
        Debug.DrawRay(RayOrigin.position,Vector2.down*RayDistance,Raycolor);
        Jump();
        Falling();

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Obstacle"))
        {
            Obstacle obstacle = other.GetComponent<Obstacle>();
            TakeDamage(obstacle.Activate());
        }
    }

    public void TakeDamage(int damage)
    {
        HealthPoints -= damage;
    }

    public void LifeCheck()
    {
        if(HealthPoints<=0)
        {
            Time.timeScale = 0;
            GameOver.SetActive(true);
        }
    }

    public void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");


        if(x<0 && FaceRight)
        {
            Flip();
        }
        else if(x>0 && !FaceRight)
        {
            Flip();
        }

        HeroAnimator.SetBool("Running", x != 0);

        rb.linearVelocity = new Vector2(x*moveSpeed,rb.linearVelocity.y);
    }

    public void Flip()
    {
        FaceRight = !FaceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

    }

    public void PunchAttack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            HeroAnimator.SetTrigger("Punch");
        }
    }

    public void EnablePunchHitBox()
    {
        punch.HitActive();
    }

    public void DisablePunchHitBox()
    {
        punch.HitInActive();
    }

    public void Jump()
    {
        if(isGround && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x,jumpforce);
            
            HeroAnimator.SetTrigger("Jump");
        }
    }

    public void Falling()
    {
        if(rb.linearVelocity.y < 0)
        {
            rb.gravityScale = DefaultGravity * 3;
            HeroAnimator.SetBool("Fall",true);
        }
        else
        {
            rb.gravityScale = DefaultGravity;
            HeroAnimator.SetBool("Fall",false);
        }
    }

}
