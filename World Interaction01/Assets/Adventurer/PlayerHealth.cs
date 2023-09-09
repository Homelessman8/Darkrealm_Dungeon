using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    //public float speed;
    [SerializeField] public TextMeshProUGUI healthBar;
    public GameObject GameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.text = playerHealth.ToString();
    }
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        Debug.Log("Player hurt");
        healthBar.text = playerHealth.ToString();
        // if zombie health reaches 0, die
        if (playerHealth <= 0)
        {
            Die();
            GameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    private void Die()
    {
        Debug.Log("player has been defeated!");
    }
}
