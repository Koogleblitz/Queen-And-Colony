using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EggSpawnProcedure : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    public float spawntime=3;
    public GameObject workerants;

    float timer = 0f;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=spawntime)
        {
            Instantiate(workerants,rgbd2d.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
