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
    public List<Transform> EnemyList;
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
        self=GameManager.instance.player.transform;
        float minimumDistance = Mathf.Infinity;
        if(nearestEnemy!=null)
        {
            minimumDistance=Vector3.Distance(self.position,nearestEnemy.position);
        }
        nearestEnemy = null;
        foreach(Transform enemy in EnemyList)
        {
            float distance = Vector3.Distance(self.position, enemy.position);
            if ( distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestEnemy = enemy;
            }
        }
        Debug.Log("Nearest Enemy: " + nearestEnemy + "; Distance: " + minimumDistance);
    }

}
