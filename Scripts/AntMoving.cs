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
    }

    void Update()
    {
        timer += Time.deltaTime;
        // Random walk
        self=gameObject.transform;
        float minimumDistance = Mathf.Infinity;
        if(nearestEnemy!=null)
        {
            minimumDistance=Vector3.Distance(self.position,nearestEnemy.position);
        }
        nearestEnemy = null;

        List<Transform> enemyList;
        enemyList=GameManager.instance.discoveredEnemyList;


        foreach(Transform enemy in enemyList)
        {
            Debug.Log("haveenemy"+enemy);
            float distance = Vector3.Distance(self.position, enemy.position);
            if ( distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestEnemy = enemy;
            }
        }
        Debug.Log("Self Pos"+self.position);
        Debug.Log("Enemy pos"+nearestEnemy);
        Debug.Log("Nearest Enemy: " + nearestEnemy + "; Distance: " + minimumDistance);
        Vector3 v3 = nearestEnemy.position - self.position;
        Vector2 v2 = new Vector2(v3.x,v3.y);
        rgbd2d.velocity = v2;
    }

}
