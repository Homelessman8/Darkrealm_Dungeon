using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public GameObject GameOverUI;

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
                GameOverUI.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
