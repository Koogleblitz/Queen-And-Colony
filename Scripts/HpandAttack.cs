using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpandAttack : MonoBehaviour
{

    public int HitPoints = 100;
    public int attackPower = 10;
    public bool side = true; // true means true enemy
    float attackInterval = 0.5f;
    float timeInterval = 10f;

    // Update is called once per frame
    void Update()
    {
        Transform self = gameObject.transform;
        GameObject nearestEnemy = GameManager.instance.FindCloestEnemy(self,side);
        float mindist = Vector3.Distance(self.position,nearestEnemy.transform.position);

        Debug.Log("Min dist is "+mindist);
        if (HitPoints <= 1)
        {
            Debug.Log("This is died"+side);
            if(side)
                GameManager.instance.antList.Remove(gameObject);
            else
                GameManager.instance.enemyList.Remove(gameObject);
            Destroy(gameObject);
        }
        if(mindist<3.5)
        {
            timeInterval += Time.deltaTime;
            if(timeInterval>attackInterval)
            {
                OnCombact(nearestEnemy);
                timeInterval=0;
            }
        }
    }

    void OnCombact(GameObject nearestEnemy)
    {
        // attack
        nearestEnemy.SendMessage("HpChange",-attackPower);
    }


    public void HpChange(int num)
    {
        HitPoints+=num;
    }

}
