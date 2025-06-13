using UnityEngine;

public class SpikeFall : MonoBehaviour
{
    public int gforce = 2;
    private bool HasFallen = false;

    private Rigidbody2D rb;
    public GameObject spike;

    void Awake()
    {
        rb = spike.GetComponent<Rigidbody2D>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            spikeTrigger();
        }
    }

    public int spikeTrigger()
    {
        if(HasFallen) return 0;
        HasFallen = true;
        rb.gravityScale = gforce;
        Debug.Log("Fall ACtivated...");
        return 0;
    }
}
