using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform loc = gameObject.transform;
        GameManager.instance.enemyList.Add(loc);
        GameManager.instance.discoveredEnemyList.Add(loc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
