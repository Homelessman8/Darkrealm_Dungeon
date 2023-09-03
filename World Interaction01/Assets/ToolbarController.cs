using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarController : MonoBehaviour
{
    [SerializeField] int toolbarSize = 9;
    int selectedTool; //holds the ID of the currently selected tool

    
    //add scroll functionality so we can scroll on the toolbar
    private void Update()
    {
        //if input deltaScroll is not equal to zero, check if it is higher or lower than zero
        //based on that, add or subtract 1 from selected tool
        float delta = Input.mouseScrollDelta.y;
        if(delta != 0)
        {
            if (delta > 0)
            {
                selectedTool +=1;
                selectedTool = (selectedTool >= toolbarSize ? 0 : selectedTool);
            }
            else
            {
                selectedTool -= 1;
                selectedTool = (selectedTool < 0 ? toolbarSize - 1 : selectedTool);
            }
            Debug.Log(selectedTool);
        }
   
    }
    internal void Set(int id)
    {
        selectedTool = id;
    }
}
