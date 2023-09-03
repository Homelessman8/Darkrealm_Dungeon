using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    //if 'I'is pressed, inverse the active state of the inventory panel
    [SerializeField] GameObject panel;
    [SerializeField] GameObject toolbarPanel; //Hide the toolbar when you open the game

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            panel.SetActive(!panel.activeInHierarchy);
            toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy);
        }
    }
}
