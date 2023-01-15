using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpandAttack : MonoBehaviour
{

    public int HitPoints = 100;
    public int attackPower = 10;
    public bool side = true; // true means true enemy

    // Update is called once per frame
    void Update()
    {
        Transform self = gameObject.transform;
        List<GameObject> thelist = side?enemyList[ind]:antList[ind];
        int ind = GameManager.instance.FindCloestEnemy(self,side);
        GameObject nearestEnemy = GameManager.instance.thelist[ind];
        float mindist = Vector3.Distance(self.position,nearestEnemy.transform.position);

        Debug.Log("Min dist is "+mindist);
        // if (HitPoints <= 1)
        // {
        //     Debug.Log("This is died"+side);

        //     Destroy(gameObject);
        // }
        if(mindist<3.5)
        {
            OnCombact(nearestEnemy);
        }
    }

    void OnCombact(int ind)
    {
        // attack
        GameObject nearestEnemy=GameManager.instance.side?enemyList[ind]:antList[ind];
        HpandAttack haa = nearestEnemy.GetComponent("HpandAttack") as HpandAttack;
        if(haa.HitPoints<=0)
        {
            if(side)
                GameManager.instance.enemyList.Remove(nearestEnemy);
            else
                GameManager.instance.antList.RemoveAt(nearestEnemy);
            haa.Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    // public void HpChange(int num)
    // {
    //     HitPoints+=num;
    // }

}
