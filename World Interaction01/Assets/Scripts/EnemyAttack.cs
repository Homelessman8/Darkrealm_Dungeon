using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 2f; // The range at which the enemy can attack.
    public float attackCooldown = 2f; // The time between attacks.
    public int attackDamage = 1; // The damage dealt to the player per attack.

    private Transform player; // Reference to the player's Transform.
    private float nextAttackTime; // The time when the enemy can attack again.

    public GameObject GameOverUI;

    private void Start()
    {
        // Find the player GameObject by tag (assuming your player has a "Player" tag).
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Check if it's time for the enemy to attack.
        if (Time.time >= nextAttackTime)
        {
            // Calculate the distance between the enemy and the player.
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // If the player is within the attack range, attack.
            if (distanceToPlayer <= attackRange)
            {
                Attack();
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    private void Attack()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
        //if (playerHealth.playerHealth <= 0)
        //{
        //    GameOverUI.SetActive(true);
        //}
        //else
        //{
        //    GameOverUI.SetActive(true);
        //}
    }
}
