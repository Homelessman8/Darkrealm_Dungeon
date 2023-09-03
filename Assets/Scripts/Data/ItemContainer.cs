using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public Item item;
    public int count;

    //add ability to copy the state of item slot
    public void Copy(ItemSlot slot)
    {
        item = slot.item;
        count = slot.count;
    }

    //method to setup item in item slot
    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }

    public void Clear()
    {
        item = null;
        count = 0;
    }
}

[CreateAssetMenu(menuName ="Data/Item Container")] 
public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots;
    //if the state of the item container is being changed, 'isDirty' is set to true
    public bool isDirty;

    //method to add item to the item container
    public void Add(Item item, int count = 1)
    {
        isDirty = true;


        if (item.stackable == true) //check if item is stackable. If it is not, find an empty slot for it
        {
            ItemSlot itemSlot = slots.Find(x => x.item == item);
            if(itemSlot != null)
            {
                itemSlot.count += count;
            }
            else
            {
                itemSlot = slots.Find(x => x.item == null);
                if(itemSlot != null)
                {
                    itemSlot.item = item;
                    itemSlot.count = count;
                }
            }
        }
        else //add non stackable item to our item container
        {
            ItemSlot itemSlot = slots.Find(x => x.item == null);
            if (itemSlot == null) //if there are no empty slots, do not store item in item container
            {
                itemSlot.item = item;
            }
        }
    }
}
