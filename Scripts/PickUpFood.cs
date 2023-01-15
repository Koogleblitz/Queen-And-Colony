using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFood : MonoBehaviour
{

    //NOTE: requires player object to be named "MainCharacter"

    // how much food the player gets upon pickup
    [SerializeField] int foodValue = 10;

    [SerializeField] float pickUpDistance = 1.5f;

    // if true, item will live for itemLifetime then self destruct, otherwise wait until picked up
    [SerializeField] bool itemSelfDestructs = false;

    // how long the item lives (if itemSelfDestructs == TRUE)
    [SerializeField] float itemLifetime = 10f;



    private void Awake()
    {

    }
    private void Update()
    {
        Vector3 playerPosition = GameObject.Find("MainCharacter").transform.position;
        if (itemSelfDestructs)
        {
            itemLifetime -= Time.deltaTime;
            if (itemLifetime < 0)
            {
                Destroy(gameObject);
            }
        }

        float playerDistance = Vector3.Distance(transform.position, playerPosition);
        if (playerDistance < pickUpDistance)
        {
            Destroy(gameObject);

            // give food to player
            GameManager.instance.currentfood += foodValue;
        }
    }
}
