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

    public List<GameObject> enemyList = new List<GameObject>();
    public List<GameObject> antList = new List<GameObject>();

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
                    float plusx = Random.Range(0f,50f);
                    spawnPosition.x += (Random.Range(0,2)*2-1)*plusx;
                    spawnPosition.y += (Random.Range(0,2)*2-1)*Mathf.Sqrt(2500-plusx*plusx);

                    GameObject go = Instantiate(spawnType);
                    go.transform.position = spawnPosition;
                    enemyList.Add(go);
                }
            }
        }
    }


    public GameObject FindCloestEnemy(Transform self, bool side) // true means true enemy :)
    {
        GameObject nearestEnemy = null; // for that side
        List<GameObject> thelist = new List<GameObject>();
        
        if(side==true) {
            thelist = enemyList;
        }
        else{
            thelist = antList;
        }
        float minimumDistance = Mathf.Infinity;
        foreach(GameObject enemy in thelist)
        {
            float distance = Vector3.Distance(self.position, enemy.transform.position);
            if (distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestEnemy = enemy;
            }
        }
        return nearestEnemy;
    }

    public GameObject player;
}
