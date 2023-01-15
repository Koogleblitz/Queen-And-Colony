using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolCharacterController : MonoBehaviour
{
    CharacterController2D character;
    public GameObject nests;
    public GameObject eggs;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1f;

    private void Awake()
    {
        character = GetComponent<CharacterController2D>();
        rgbd2d = GetComponent<Rigidbody2D>();
        rgbd2d.gravityScale= 0;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            UseTool();
        }

        if(Input.GetKey("q"))
        {
            PlaceNest();
        }

        if(Input.GetKey("e"))
        {
            if(GameManager.instance.currentfood>0)
            {
                PlaceEggs();
            }
        }
    }

    private void UseTool()
    {
        float sizeOfInteractableArea = 1.2f;
        Vector2 position = rgbd2d.position + character.lastMotionVector * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interact hit = c.GetComponent<Interact>();
            if (hit!=null)
            {
                hit.Hit();
                break;
            }
        }
    }

    private void PlaceNest()
    {
        float sizeOfInteractableArea = .4f;
        Vector2 p5 = new Vector2(.5f,.5f);
        Vector2 position = rgbd2d.position;// + character.lastMotionVector * offsetDistance;
        Vector2Int v2i = Vector2Int.RoundToInt(position+p5);
        Vector3 placePosition = new Vector3(v2i.x-.5f, v2i.y-.5f, 0f);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(placePosition, sizeOfInteractableArea);

        Debug.Log("length %d\n"+colliders.Length);
        if(colliders.Length<=1)
        {
            Instantiate(nests,placePosition, Quaternion.identity);
        }
    }

    private void PlaceEggs()
    {

        float sizeOfInteractableArea = .4f;
        Vector2 p5 = new Vector2(.5f,.5f);
        Vector2 position = rgbd2d.position;// + character.lastMotionVector * offsetDistance;
        Vector2Int v2i = Vector2Int.RoundToInt(position+p5);
        Vector3 placePosition = new Vector3(v2i.x-.5f, v2i.y-.5f, 0f);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(placePosition, sizeOfInteractableArea);

        Debug.Log("length %d\n"+colliders.Length);
        if(colliders.Length<=1)
        {
            GameManager.instance.currentfood-=10;
            Instantiate(eggs,placePosition, Quaternion.identity);
        }
    }


}
