using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script stores information about the items
[CreateAssetMenu(menuName ="Data/Item")]

public class Item : ScriptableObject
{
    public string Name;
    public bool stackable;
    public Sprite icon;
}
