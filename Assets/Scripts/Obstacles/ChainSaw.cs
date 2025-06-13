using UnityEngine;

public class ChainSaw : Obstacle
{
    public int damage = 2;
    public override int Activate()
    {
        Debug.Log("Saw Activated...");
        return damage;
    }
}
