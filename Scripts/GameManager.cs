using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int[] foodRequirement = {10,20,50,100};
    public int[] timeSpawn       = {3,5,10,20};
    // TODO If we have time 
    // Greater ants needs more food and time spawn

    public List<Rigidbody2D> enemyList;
    public List<Rigidbody2D> discoveredEnemyList;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject player;
}
