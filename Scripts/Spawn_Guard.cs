using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Guard : MonoBehaviour
{
    public GameObject prefab;
    public uint popCap;
    public uint randerosity;
    uint cnt= 0;
    void Update(){
        var selfPos= this.transform.position;
        Unity.Mathematics.Random rand= new Unity.Mathematics.Random(1);
        Vector3 randRange= new Vector3(1,1,0)*randerosity;
        Vector3 randPos= rand.NextFloat3(selfPos-randRange, selfPos+randRange);
        randPos.z= 0;

        if(cnt<popCap){
            Instantiate(prefab, transform.position, UnityEngine.Random.rotation);
        }

        cnt= (cnt<popCap)? cnt+1 : popCap;
        UnityEngine.Debug.Log(cnt);
    }
}
