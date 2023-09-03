using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragAndDropController : MonoBehaviour
{
    //declare slot for the currently selected item, which will be dragged around
    [SerializeField] ItemSlot itemSlot;

    //declare seriealized item drag and drop
    [SerializeField] GameObject itemIcon;

    //store the reference to the RectTransform of the icon on the start
    RectTransform iconTransform;

    Image itemIconImage;

    private void Start()
    {
        itemSlot = new ItemSlot();
        iconTransform = itemIcon.GetComponent<RectTransform>();
        itemIconImage = itemIcon.GetComponent<Image>();
    }

    private void Update()
    {
        //check if itemIcon isActive in hierarchy 
        if (itemIcon.activeInHierarchy == true)
        {
            //then assign mouse position to the item icon
            iconTransform.position = Input.mousePosition;

            //if we want to throw away some junk, we detect if we click inside or outside the inventory panel
            if (Input.GetMouseButtonDown(0))
            {
                if(EventSystem.current.IsPointerOverGameObject() == false) //if not over any UI elements
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Convert mouse position to world position
                    worldPosition.z = 0; //nullify position to make sure that item shows up on screen
                    

                    ItemSpawnManager.instance.SpawnItem(
                        worldPosition, 
                        itemSlot.item, 
                        itemSlot.count
                        );

                    //Clear drag and drop item slot after item is dropped
                    itemSlot.Clear();
                    itemIcon.SetActive(false); //set item icon to false to hide it
                }
            }
        }
    }

    internal void OnClick(ItemSlot itemSlot)
    {
        if(this.itemSlot.item == null) //copy the past item slot into the drag and drop slot then clear the past drag and drop slot
        {
            this.itemSlot.Copy(itemSlot);
            itemSlot.Clear();
        }
        //if the item slot is not empty, we want to swap the item inside the slots
        else
        {
            Item item = itemSlot.item;
            int count = itemSlot.count;

            itemSlot.Copy(this.itemSlot);
            this.itemSlot.Set(item, count);
        }
        //assign item icon to the dragged item icon
        UpdateIcon();
    }

    //method to check if there is something in the drag and drop slot
    //if there is, activate icon object and place icon sprite into the icon object
    //if not, hide the icon
    private void UpdateIcon()
    {
        if (itemSlot.item == null)
        {
            itemIcon.SetActive(false);
        }
        else
        {
            itemIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.icon;
        }
    }

    //Ability to move item inside our inventory. SO when you click the item, it should be moved to the item
    //drag and drop slot and removed from the inventory.
}
