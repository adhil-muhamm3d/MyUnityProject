using UnityEngine;

public class SpikeDamage : Obstacle
{
    public int Damage = 3;
    private bool DamageTaken = false;
    
    public override int Activate()
    {
        if(DamageTaken) return 0;
        DamageTaken = true;
        return Damage;
    }
}
