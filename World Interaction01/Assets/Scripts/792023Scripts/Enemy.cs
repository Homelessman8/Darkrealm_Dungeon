using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    [SerializeField] private TextMeshProUGUI healthBar;

    private Animator anim;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("damage TAKEN");
        healthBar.text = health.ToString();
    }
}
