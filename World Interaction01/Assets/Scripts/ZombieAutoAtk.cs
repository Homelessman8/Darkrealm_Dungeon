using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAutoAtk : MonoBehaviour
{
    public GameObject player;         // Reference to the player GameObject.
    public float speed;               // Speed at which the zombie moves.
    public float distanceBetween;     // Minimum distance to start moving towards the player.
    public Animator anim;             // Reference to the Animator component.

    private Vector2 directionV;       // Direction vector from zombie to player.
    private bool IsInRange;           // Flag indicating if the player is in range.
    private Vector2 defaultPos;       // Default position of the zombie.
    private float distance;           // Distance between the zombie and the player.

    // Reference to the Enemy script.
    public Enemy eH;

    // Reference to the Rigidbody2D component.
    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize default position and get the Rigidbody2D component.
        defaultPos = transform.position;
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eH.health > 0)
        {
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

                // Set the "Idle" animation to false.
                anim.SetBool("Idle", false);
            }
            else if (distance > distanceBetween)
            {
                directionV = Vector2.zero;

                // Set the "Idle" animation to true.
                anim.SetBool("Idle", true);
            }

            // Set the "DirectAnim" parameter of the Animator based on the direction.
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
