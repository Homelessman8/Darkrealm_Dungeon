using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack; //prevent spamming attacks
    public float startTimeBetweenAttack;

    public Transform attackPos;//position of circle which detects enemies
    public LayerMask whatIsEnemies; //looks for enemies on the layer
    public float attackRange; //range of attack
    public int damage;

    public ItemCollector iC; //inherit from ItemCollector Script to read weaponEquipped
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(timeBetweenAttack <= 0)
        {
            //then I can attack
            //if(Input.GetKeyDown(KeyCode.Mouse0) && iC.weaponEquipped == true) //attack key replace with left click
            //{
            //    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies); //check for enemies inside a certain radius
            //    for (int i = 0; i < enemiesToDamage.Length; i++) //look for enemies within the circle
            //    {
            //        enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            //    }
            //}

            //trial 1 for bug: zombie still taking damage x2 when no weapon is equipped
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                if (iC.weapon != 0)
                {
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies); //check for enemies inside a certain radius
                    for (int i = 0; i < enemiesToDamage.Length; i++) //look for enemies within the circle
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
               return;
            }
            timeBetweenAttack = startTimeBetweenAttack;
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        //visualize range and shape of the player's attack
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    void Attack()
    {
        //play an attack animation
        animator.SetTrigger("attack");
    }
}
