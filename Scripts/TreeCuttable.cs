using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : Interact
{

    public override void Hit()
    {
        Destroy(gameObject);
    }
}
