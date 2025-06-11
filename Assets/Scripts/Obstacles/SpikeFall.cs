using UnityEngine;

public class SpikeFall : Obstacle
{
    public int gforce = 2;
    private bool HasFallen = false;

    private Rigidbody2D rb;
    public GameObject spike;

    void Awake()
    {
        rb = spike.GetComponent<Rigidbody2D>();
    }

    public override int Activate()
    {
        if(HasFallen) return 0;
        HasFallen = true;
        rb.gravityScale = gforce;
        Debug.Log("Fall ACtivated...");
        return 0;
    }
}
