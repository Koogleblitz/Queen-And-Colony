using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int[] foodRequirement = {10,20,50,100};
    public int[] timeSpawn       = {3,5,10,20};
    // TODO If we have time 

    public int currentfood = 100;
    public int maxfood = 500;

    // Greater ants needs more food and time spawn

    public List<Transform> enemyList           = new List<Transform>();
    public List<Transform> discoveredEnemyList = new List<Transform>();

    // number of frames between wave spawns
    [SerializeField] int framesUntilWave = 10 * 30; //10 sec @ 30fps 

    // number of enemies that spawn per wave
    [SerializeField] int enemiesPerWave = 5;

    // object to spawn
    [SerializeField] GameObject spawnType;

    // infinite waves? true or false
    [SerializeField] bool infiniteWaves;

    // number of waves (only if infiniteWaves is FALSE)
    [SerializeField] int numberOfWaves;

    int framesRemaining; // spawns wave when < 1
    int waveCount = 0;

    private void Awake()
    {
        instance = this;
        framesRemaining = framesUntilWave;
    }

    private void Update()
    {
        // if waves to spawn
        if (infiniteWaves || waveCount < numberOfWaves)
        {
            --framesRemaining;

            // spawn wave
            if (framesRemaining < 1)
            {
                // increment waveCount if there are a limited number of waves, else ignore
                if (!infiniteWaves)
                    ++waveCount;

                // reset wave timer
                framesRemaining = framesUntilWave;

                // spawn enemies
                for (int i = 0; i < enemiesPerWave; ++i)
                {
                    // spawn them 100 units north of player
                    Vector3 spawnPosition = GameObject.Find("MainCharacter").transform.position;
                    spawnPosition.y += 100;

                    GameObject go = Instantiate(spawnType);
                    go.transform.position = spawnPosition;
                }
            }
        }
    }

    public GameObject player;
}
