using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public GameObject GameOverUI; // Reference to the game over UI GameObject.

    // This method is called when a Collider2D enters the trigger zone.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the lava is the player (you can adjust the player's tag or use another method).
        if (other.CompareTag("Player"))
        {
            // Assuming the player has a PlayerHealth script with a Die method to handle player death.
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Call the Die method to handle player death.
                GameOverUI.SetActive(true); // Activate the game over UI.
                Time.timeScale = 0f; // Pause the game.
            }
        }
    }
}

