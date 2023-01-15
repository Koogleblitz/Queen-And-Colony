using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AntMoving : MonoBehaviour
{

    // for the soldier ants, random walk when no enemy, a* for route tracing
    Rigidbody2D rgbd2d;
    float timer = 0f;

    Transform self;
    private Transform nearestEnemy;

	void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        rgbd2d.gravityScale= 0;
        GameManager.instance.antList.Add(gameObject);
    }

    void Update()
    {
        // timer += Time.deltaTime;
        // Random walk
        self=gameObject.transform;
        int ind = GameManager.instance.FindCloestEnemy(self,true);
        nearestEnemy=GameManager.instance.enemyList[ind].transform;
        Vector3 v3 = nearestEnemy.position - self.position;
        Vector2 v2 = new Vector2(v3.x,v3.y);

        rgbd2d.velocity = v2.normalized*3;
    }

}
