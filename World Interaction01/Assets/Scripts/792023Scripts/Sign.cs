using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox; //reference the dialog box 
    public Text dialogText; //reference a string that we want the dialog box to display
    public string dialog;
    public bool playerInRange; //say whether or not dialog box should be active 

    // Start is called before the first frame update
    void Start()
    {
        // Initially, hide the dialog box.
        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            // If the player is in range, show the dialog box and set the text.
            dialogBox.SetActive(true);
            dialogText.text = dialog;
        }
        else
        {
            // If the player is out of range, hide the dialog box.
            dialogBox.SetActive(false);
        }
    }
    // Check whether the player collides with the collision box.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    // Check whether the player exits the collision box.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}



