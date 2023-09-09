using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    [SerializeField] private TextMeshProUGUI healthBar;

    public Animator anim;

    private void Start()
    {
        healthBar.text = health.ToString();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("damage TAKEN");
        if (health >= 0)
        {
            healthBar.text = health.ToString();
            // if zombie health reaches 0, die
            if (health <= 0)
            {
                //anim.SetBool("isDefeated", true); //bool isDefeated set to true in the animator
                //anim.SetTrigger("isDead");
                Die();
            }
        }
        else
        {
            health = 0;
        }

    }
    private void Die()
    {
        Debug.Log("Enemy has been defeated!");
        anim.SetBool("isDefeated", true); //bool isDefeated set to true in the animator
        anim.SetTrigger("isDead");
        // Destroy the enemy GameObject from the scene.
        Destroy(gameObject, 2f);
    }
}
