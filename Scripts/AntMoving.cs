using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AntMoving : MonoBehaviour
{

    // for the soldier ants, random walk when no enemy, a* for route tracing
    Rigidbody2D rgbd2d;
    float timer = 0f;


	void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        rgbd2d.gravityScale= 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // Random walk

        // Find enemy
    }

/*
    // for enemy finding
    public Transform Player;

    //First add your enemy transform in C# List
    public List<Transform> EnemyList;

    private KdTree<Transform> enemyKdTree = new KdTree<Transform>();
    private Transform nearestEnemy;

    void Start()
    {
        // Update EnemyKdTree
        enemyKdTree.AddAll(EnemyList);
    }

    void Update()
    {
        if (nearestEnemy != null)
        {
            nearestEnemy.GetComponent<MeshRenderer>().material.color = Color.green;
        }

        // get closest object
        nearestEnemy = enemyKdTree.FindClosest(Player.position);

        nearestEnemy.GetComponent<MeshRenderer>().material.color = Color.red;
        float distance = Vector3.Distance(Player.position, nearestEnemy.position);
        Debug.Log("Nearest Enemy: " + nearestEnemy + "; Distance: " + distance);
    }
    */

}
