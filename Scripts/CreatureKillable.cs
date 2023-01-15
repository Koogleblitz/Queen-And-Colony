using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureKillable : ToolHit
{
    [SerializeField] int hitPoints = 2;

    public override void Hit()
    {
        // take damage, but not dead yet
        if (hitPoints > 1)
        {
            --hitPoints;
        }
        else // dead
        {
            Destroy(gameObject);
        }
    }
}
