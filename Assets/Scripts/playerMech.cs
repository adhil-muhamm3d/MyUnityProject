using UnityEngine;

public class playerMech : MonoBehaviour
{

    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    [SerializeField] private float moveSpeed;
    public Animator HeroAnimator;

    private bool FaceRight = true;

    public Punch punch;

    void Update()
    {
        PunchAttack();
    }

    void FixedUpdate()
    {
        Movement();
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

}
