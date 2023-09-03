using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
    characterController2D character;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1f; // defines the distance in which the tool will be used relative to the character's position
    [SerializeField] float sizeOfInteractableArea = 1.2f; //defines the radius of the area where the tool can interact with objects

    private void Awake()
    {
        character = GetComponent<characterController2D>();
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            useTool();
        }
    }

    private void useTool()
    {
        Vector2 position = rgbd2d.position + character.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach(Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }
}
