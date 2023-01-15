using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class SpawnLocalMushrooms : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    [SerializeField] float maxSpawnRadius = 3.5f;
    [SerializeField] float minSpawnRadius = 1.5f;

    // maximum number of mushrooms to spawn, eating them allows more to grow again
    [SerializeField] int mushroomsToMaintain = 5;

    [SerializeField] bool respawnAllowed = true;

    [SerializeField] float respawnTimer = 20;

    [SerializeField] GameObject mushroomObject;


    const int MAX_MUSHROOMS = 6;
    const float COLLISION_CHECK_RADIUS = 0.05f;

    float spawnTimer = 0;

    Vector2 mushroom1;
    Vector2 mushroom2;
    Vector2 mushroom3;
    Vector2 mushroom4;
    Vector2 mushroom5;
    Vector2 mushroom6;
    Vector2 mushroom7;
    Vector2 mushroom8;
    Vector2 mushroom9;
    Vector2 mushroom10;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        // create randomized coordinates within the spawn radius for the mushrooms
        if (mushroomsToMaintain > 0)
        {
            //sqrt (inner^2 + random % (outer^2 - inner radius^2))
            mushroom1.x = Mathf.Sqrt(
                Mathf.Pow(minSpawnRadius, 2) +
                (UnityEngine.Random.value %
                (Mathf.Pow(maxSpawnRadius, 2) - Mathf.Pow(minSpawnRadius, 2))
                ));
            mushroom1.y = Mathf.Sqrt(
                Mathf.Pow(minSpawnRadius, 2) +
                (UnityEngine.Random.value %
                (Mathf.Pow(maxSpawnRadius, 2) - Mathf.Pow(minSpawnRadius, 2))
                ));

            mushroom2.x = Mathf.Sqrt(
                Mathf.Pow(minSpawnRadius, 2) +
                (UnityEngine.Random.value %
                (Mathf.Pow(maxSpawnRadius, 2) - Mathf.Pow(minSpawnRadius, 2))
                ));
            mushroom2.y = Mathf.Sqrt(
                Mathf.Pow(minSpawnRadius, 2) +
                (UnityEngine.Random.value %
                (Mathf.Pow(maxSpawnRadius, 2) - Mathf.Pow(minSpawnRadius, 2))
                ));

            mushroom3.x = Mathf.Sqrt(
                Mathf.Pow(minSpawnRadius, 2) +
                (UnityEngine.Random.value %
                (Mathf.Pow(maxSpawnRadius, 2) - Mathf.Pow(minSpawnRadius, 2))
                ));
            mushroom3.y = Mathf.Sqrt(
                Mathf.Pow(minSpawnRadius, 2) +
                (UnityEngine.Random.value %
                (Mathf.Pow(maxSpawnRadius, 2) - Mathf.Pow(minSpawnRadius, 2))
                ));

            mushroom4.x = Mathf.Sqrt(
                Mathf.Pow(minSpawnRadius, 2) +
                (UnityEngine.Random.value %
                (Mathf.Pow(maxSpawnRadius, 2) - Mathf.Pow(minSpawnRadius, 2))
                ));
            mushroom4.y = Mathf.Sqrt(
                Mathf.Pow(minSpawnRadius, 2) +
                (UnityEngine.Random.value %
                (Mathf.Pow(maxSpawnRadius, 2) - Mathf.Pow(minSpawnRadius, 2))
                ));

            mushroom5.x = Mathf.Sqrt(
                Mathf.Pow(minSpawnRadius, 2) +
                (UnityEngine.Random.value %
                (Mathf.Pow(maxSpawnRadius, 2) - Mathf.Pow(minSpawnRadius, 2))
                ));
            mushroom5.y = Mathf.Sqrt(
                Mathf.Pow(minSpawnRadius, 2) +
                (UnityEngine.Random.value %
                (Mathf.Pow(maxSpawnRadius, 2) - Mathf.Pow(minSpawnRadius, 2))
                ));

            mushroom6.x = Mathf.Sqrt(
                Mathf.Pow(minSpawnRadius, 2) +
                (UnityEngine.Random.value %
                (Mathf.Pow(maxSpawnRadius, 2) - Mathf.Pow(minSpawnRadius, 2))
                ));
            mushroom6.y = Mathf.Sqrt(
                Mathf.Pow(minSpawnRadius, 2) +
                (UnityEngine.Random.value %
                (Mathf.Pow(maxSpawnRadius, 2) - Mathf.Pow(minSpawnRadius, 2))
                ));
        }
    }

    private void Update()
    {
        if (respawnAllowed && mushroomsToMaintain > 0)
            spawnTimer += Time.deltaTime;

        if (respawnAllowed && spawnTimer > respawnTimer)
        {
            spawnTimer = 0;
            int maintainedMushrooms = 0;

            // check if mushrooms are alive, only respawn the ones that are dead
            Vector2 mainPosition = rigidbody2d.position;
            Vector2 comparePosition;

            // check mushroom 1
            comparePosition.x = mainPosition.x + mushroom1.x;
            comparePosition.y = mainPosition.y + mushroom1.y;

            Collider2D[] collider = Physics2D.OverlapCircleAll(comparePosition, COLLISION_CHECK_RADIUS);

            if (collider.Length <= 0 )
            {
                ++maintainedMushrooms;

                // spawn mushroom
                GameObject go = Instantiate(mushroomObject);
                go.transform.position = comparePosition;

            }

            // check mushroom 2
            if (maintainedMushrooms < mushroomsToMaintain)
            {
                ++maintainedMushrooms;

                comparePosition.x = mainPosition.x + mushroom2.x;
                comparePosition.y = mainPosition.y + mushroom2.y;

                collider = Physics2D.OverlapCircleAll(comparePosition, COLLISION_CHECK_RADIUS);

                if (collider.Length <= 0 )
                {
                    // spawn mushroom
                    GameObject go = Instantiate(mushroomObject);
                    go.transform.position = comparePosition;
                }
            }

            // check mushroom 3
            if (maintainedMushrooms < mushroomsToMaintain)
            {
                ++maintainedMushrooms;

                comparePosition.x = mainPosition.x + mushroom3.x;
                comparePosition.y = mainPosition.y + mushroom3.y;

                collider = Physics2D.OverlapCircleAll(comparePosition, COLLISION_CHECK_RADIUS);

                if (collider.Length <= 0)
                {
                    // spawn mushroom
                    GameObject go = Instantiate(mushroomObject);
                    go.transform.position = comparePosition;
                }
            }

            // check mushroom 4
            if (maintainedMushrooms < mushroomsToMaintain)
            {
                ++maintainedMushrooms;

                comparePosition.x = mainPosition.x + mushroom4.x;
                comparePosition.y = mainPosition.y + mushroom4.y;

                collider = Physics2D.OverlapCircleAll(comparePosition, COLLISION_CHECK_RADIUS);

                if (collider.Length <= 0)
                {
                    // spawn mushroom
                    GameObject go = Instantiate(mushroomObject);
                    go.transform.position = comparePosition;
                }
            }

            // check mushroom 5
            if (maintainedMushrooms < mushroomsToMaintain)
            {
                ++maintainedMushrooms;

                comparePosition.x = mainPosition.x + mushroom5.x;
                comparePosition.y = mainPosition.y + mushroom5.y;

                collider = Physics2D.OverlapCircleAll(comparePosition, COLLISION_CHECK_RADIUS);

                if (collider.Length <= 0)
                {
                    // spawn mushroom
                    GameObject go = Instantiate(mushroomObject);
                    go.transform.position = comparePosition;
                }
            }

            // check mushroom 6
            if (maintainedMushrooms < mushroomsToMaintain)
            {
                ++maintainedMushrooms;

                comparePosition.x = mainPosition.x + mushroom6.x;
                comparePosition.y = mainPosition.y + mushroom6.y;

                collider = Physics2D.OverlapCircleAll(comparePosition, COLLISION_CHECK_RADIUS);

                if (collider.Length <= 0)
                {
                    // spawn mushroom
                    GameObject go = Instantiate(mushroomObject);
                    go.transform.position = comparePosition;
                }
            }
        }
    }




}
