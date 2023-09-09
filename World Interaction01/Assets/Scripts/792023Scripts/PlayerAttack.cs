using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;     // Cooldown timer to prevent spamming attacks.
    public float startTimeBetweenAttack; // Initial time between attacks.

    public Transform attackPos;          // Position where the attack detects enemies.
    public LayerMask whatIsEnemies;      // Layer mask to filter which objects are considered enemies.
    public float attackRange;            // Range of the player's attack.
    public int damage;                   // Damage dealt to enemies.

    public ItemCollector iC;             // Reference to the ItemCollector script to check if a weapon is equipped.
    public Animator animator;            // Reference to the Animator component for animations.

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenAttack <= 0)
        {
            // If the cooldown time has passed, the player can attack.
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                if (iC.weapon != 0)
                {
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                    // Check for enemies inside a certain radius.

                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                        Attack();
                    }
                }
                else
                {
                    Attack();
                }
            }
            else
            {
                return; // No attack input detected, so do nothing.
            }

            timeBetweenAttack = startTimeBetweenAttack; // Reset the attack cooldown.
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime; // Decrease the cooldown timer.
        }
    }

    // Visualize the attack range and shape in the Unity Editor.
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    void Attack()
    {
        // Trigger the attack animation.
        animator.SetTrigger("attack");
    }
}
