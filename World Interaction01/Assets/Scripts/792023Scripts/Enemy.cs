using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int health;                    // The enemy's current health.
    public float speed;                  // The enemy's speed (if applicable).
    [SerializeField] private TextMeshProUGUI healthBar; // Reference to the health bar UI element.

    public Animator anim;                 // Reference to the Animator component for animations.

    private void Start()
    {
        healthBar.text = health.ToString(); // Initialize the health bar text with the enemy's health.
    }

    // Method to handle taking damage.
    public void TakeDamage(int damage)
    {
        health -= damage; // Reduce the enemy's health by the specified damage amount.
        Debug.Log("Damage taken"); // Log that damage has been taken by the enemy.

        // Check if the enemy's health is greater than or equal to 0.
        if (health >= 0)
        {
            healthBar.text = health.ToString(); // Update the displayed health on the health bar.

            // Check if the enemy's health has reached 0 or below.
            if (health <= 0)
            {
                Die(); // Call the Die() method to handle enemy defeat.
            }
        }
        else
        {
            health = 0; // Ensure that health doesn't go below 0.
        }
    }

    // Method to handle the enemy's defeat.
    private void Die()
    {
        Debug.Log("Enemy has been defeated!"); // Log that the enemy has been defeated.
        anim.SetBool("isDefeated", true); // Set the "isDefeated" parameter in the Animator to true.
        anim.SetTrigger("isDead"); // Trigger the "isDead" animation state.

        // Destroy the enemy GameObject from the scene after a delay (2 seconds in this case).
        Destroy(gameObject, 2f);
    }
}
