using UnityEngine;

public class Punch : MonoBehaviour
{
    public GameObject hitbox;
    public Collider2D HitBoxCollider;

    public ParticleSystem PunchEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HitBoxCollider = GetComponent<Collider2D>();
        HitBoxCollider.enabled = false;
    }

    public void HitActive()
    {
        HitBoxCollider.enabled = true;
    }

    public void HitInActive()
    {
        HitBoxCollider.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PunchingBag"))
        {
            Debug.Log("Enemy got hit");

            if(PunchEffect != null)
            {
                PunchEffect.Stop(true,ParticleSystemStopBehavior.StopEmittingAndClear);
                PunchEffect.Play();
            }
            Destroy(other.gameObject);
        }
    }

    
}
