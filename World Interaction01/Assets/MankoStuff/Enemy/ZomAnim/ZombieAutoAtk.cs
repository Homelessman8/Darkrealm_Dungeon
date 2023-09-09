using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAutoAtk : MonoBehaviour
{
    public GameObject player;         // Reference to the player GameObject.
    public float speed;               // Speed at which the zombie moves.
    public float distanceBetween;     // Minimum distance to start moving towards the player.
    public Animator anim;

    private Vector2 directionV;
    private bool IsInRange;
    private Vector2 defaultPos;
    private float distance;           // Distance between the zombie and the player.

    //calling the Enemy script 
    public Enemy eH;
    private Rigidbody2D rb2D; // Reference to the Rigidbody2D component.


    // Start is called before the first frame update
    void Start()
    {
        // This method is called once when the script starts.
        // You can initialize any variables or setup here if needed.
        defaultPos = transform.position;
        rb2D = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component.
    }

    // Update is called once per frame
    void Update()
    {
        if (eH.health > 0)
        {
            //Debug.Log("line 1");
            //move towards player 
            //Debug.Log("this id x and y pos:" + defaultPos.x + defaultPos.y );
            // Calculate the distance between the zombie and the player.
            distance = Vector2.Distance(transform.position, player.transform.position);


            // Check if the player is within the specified distance.
            if (distance < distanceBetween)
            {
                // Move the zombie towards the player with the specified speed.
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                // Calculate the direction vector from the zombie to the player.
                directionV = player.transform.position - transform.position;
                directionV.Normalize();  // Normalize the vector to get a unit vector.

                // Calculate the angle in degrees based on the direction vector.
                float angle = Mathf.Atan2(directionV.y, directionV.x) * Mathf.Rad2Deg;
                anim.SetBool("Idle", false);
            }
            else if (distance > distanceBetween)
            {
                directionV = Vector2.zero;
                anim.SetBool("Idle", true);
            }
            anim.SetFloat("DirectAnim", directionV.x);
        }
        else
        {
            // Zombie is dead, stop moving and playing animations.
            directionV = Vector2.zero;
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
