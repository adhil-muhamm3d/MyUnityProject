using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public int Damage = 3;
    private bool DamageTaken = false;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !DamageTaken)
        {
            DamageTaken = true;
            other.GetComponent<playerMech>()?.TakeDamage(Damage);
        }

    }
}
