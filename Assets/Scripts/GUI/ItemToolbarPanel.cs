using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToolbarPanel : ItemPanel
{
    [SerializeField] ToolbarController toolbarController;

    private void Start()
    {
        Init();
        //subscribe highlight method to the delegate in the toolbar controller
        toolbarController.onChange += Highlight;
        Highlight(0); //when game starts, by default highlight the first item in toolbar
    }

    public override void OnClick(int id)
    {
        toolbarController.Set(id);
        Highlight(id);
    }

    int currentSelectedTool; //store the currently highlighted tool

    //highlight the button and remove highlight of previously selected slot
    public void Highlight(int id)
    {
        buttons[currentSelectedTool].Highlight(false);
        currentSelectedTool = id;
        buttons[currentSelectedTool].Highlight(true);
    }
}
