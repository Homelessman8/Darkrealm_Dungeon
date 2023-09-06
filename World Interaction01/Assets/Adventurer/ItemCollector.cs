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
    }
}
