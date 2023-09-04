using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAutoAtk : MonoBehaviour
{
    public GameObject player;         // Reference to the player GameObject.
    public float speed;               // Speed at which the zombie moves.
    public float distanceBetween;     // Minimum distance to start moving towards the player.

    private Animator anim;
    private float distance;           // Distance between the zombie and the player.

    // Start is called before the first frame update
    void Start()
    {
        // This method is called once when the script starts.
        // You can initialize any variables or setup here if needed.
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between the zombie and the player.
        distance = Vector2.Distance(transform.position, player.transform.position);

        // Calculate the direction vector from the zombie to the player.
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();  // Normalize the vector to get a unit vector.

        // Calculate the angle in degrees based on the direction vector.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Check if the player is within the specified distance.
        if (distance < distanceBetween)
        {
            // Move the zombie towards the player with the specified speed.
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            // Rotate the zombie to face the player based on the calculated angle.
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }


        //Animation for Zombie Movement

        if(direction.x > 0f)
        {
            anim.SetBool("MoveRight", true);
            //anim.SetBool("MoveLeft", false);
            //anim.SetBool("MoveFront", false);
            //anim.SetBool("MoveBack", false);
            //anim.SetBool("IdleFront", false);
        }
        else if (direction.x < 0f)
        {
            //anim.SetBool("MoveRight", false);
            anim.SetBool("MoveLeft", true);
            //anim.SetBool("MoveFront", false);
            //anim.SetBool("MoveBack", false);
            //anim.SetBool("IdleFront", false);
        }
        else if (direction.y < 0f)
        {
            //anim.SetBool("MoveRight", false);
            //anim.SetBool("MoveLeft", false);
            anim.SetBool("MoveFront", true);
            //anim.SetBool("MoveBack", false);
            //anim.SetBool("IdleFront", false);
        }
        else if (direction.y > 0f)
        {
            //anim.SetBool("MoveRight", false);
            //anim.SetBool("MoveLeft", false);
            //anim.SetBool("MoveFront", false);
            anim.SetBool("MoveBack", true);
            //anim.SetBool("IdleFront", false);
        }
        else
        {
            anim.SetBool("IdleFront", true);
        }
    }
}
