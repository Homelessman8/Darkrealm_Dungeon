using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth; // Variable to store the player's health.

    [SerializeField] public TextMeshProUGUI healthBar; // Reference to the UI element displaying health.
    public GameObject GameOverUI; // Reference to the game over screen UI.

    // Start is called before the first frame update
    void Start()
    {
        healthBar.text = playerHealth.ToString(); // Initialize health display with player's initial health.
    }

    // Method to handle player taking damage.
    public void TakeDamage(int damage)
    {
        playerHealth -= damage; // Reduce player's health by the specified damage amount.
        Debug.Log("Player hurt"); // Log player getting hurt.

        healthBar.text = playerHealth.ToString(); // Update health display on the UI.

        // Check if player's health is zero or below.
        if (playerHealth <= 0)
        {
            Die(); // Call the Die() method to handle player defeat.
            GameOverUI.SetActive(true); // Activate the game over screen UI.
            Time.timeScale = 0f; // Pause the game.
        }
    }

    // Method to handle player's defeat.
    private void Die()
    {
        Debug.Log("Player has been defeated!"); // Log player defeat.
        // Add additional actions here, such as restarting the level or showing a game over menu.
    }
}
