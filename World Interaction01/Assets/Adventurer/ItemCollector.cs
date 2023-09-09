using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int coins = 0; //Count the coins
    public int weapon = 0; //Count the weapons
    //weaponEquipped checks if the player is armed
    public bool weaponEquipped;
    Animator animator;

    //call PlayerHealth script
    public PlayerHealth pH;

    [SerializeField] private TextMeshProUGUI coinText;

    void Awake()
    {
        //rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //when we collide with the item
    private void OnTriggerEnter2D(Collider2D collision)//because items are set to istrigger
    {
        if (collision.gameObject.CompareTag("Coin"))//if we are colliding with a coin
        {
            //make the item disappear from the game
            Destroy(collision.gameObject);
            coins++; //increment count after collecting coin
            coinText.text = "Coins: " + coins;
            //Debug.Log("Coins: " + coins);
        }

        if (collision.gameObject.CompareTag("Weapon"))//if we are colliding with a weapon
        {
            //make the item disappear from the game
            Destroy(collision.gameObject);
            weapon++; //increment count after collecting weapon
            //coinText.text = "Coins: " + coins;
            Debug.Log("Weapon obtained: " + weapon);
            if (weapon != 0)
            {
                animator.SetBool("weaponEquipped", weaponEquipped);
            }
        }

        //if we are colliding with a heart
        if (collision.gameObject.CompareTag("Heart"))
        {
            if (pH.playerHealth == 20) //if player health is full
            {
                pH.playerHealth = 20; //don't collect the powerup
                Debug.Log("Health is already Max");
            }
            if (pH.playerHealth < 20)
            {
                Destroy(collision.gameObject);
                pH.playerHealth += 5; //replenish health only up to 20 
                Debug.Log("health: " + pH.playerHealth);
                pH.healthBar.text = pH.playerHealth.ToString();

                // Ensure health doesn't go above 20.
                if (pH.playerHealth > 20)
                {
                    pH.playerHealth = 20;
                    pH.healthBar.text = pH.playerHealth.ToString();
                }
            }
        }


    }
}
