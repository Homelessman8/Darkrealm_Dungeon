using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;  // Reference to the dialog box GameObject.
    public Text dialogText;       // Reference to the Text component for displaying dialog text.
    public string dialog;         // The dialog text to be displayed.
    public bool playerInRange;    // Indicates whether or not the player is in range to trigger the dialog.

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
            playerInRange = true; // Set playerInRange to true when the player enters the trigger zone.
        }
    }

    // Check whether the player exits the collision box.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false; // Set playerInRange to false when the player exits the trigger zone.
        }
    }
}
