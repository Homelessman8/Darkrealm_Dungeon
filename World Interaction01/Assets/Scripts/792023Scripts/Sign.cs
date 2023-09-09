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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange) //check if action key is pressed when the player is in range ( )
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);                
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    //check whether player collides with collision box
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    //check whether player exits collision box
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
