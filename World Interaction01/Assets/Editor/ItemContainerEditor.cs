using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(ItemContainer))]
public class ItemContainerEditor : Editor
{
    //Create our own editor GUI. It will contain a simple button to clean up the inventory instead of 
    //having to clear out each slot manually
    public override void OnInspectorGUI()
    {
        //Create GUI layout button and cycle inside the container to clean each slot
        ItemContainer container = target as ItemContainer;
        if(GUILayout.Button("Clear container"))
        {
            for(int i = 0; i < container.slots.Count; i++)
            {
                container.slots[i].Clear();
            }
        }
        DrawDefaultInspector(); //draws what we can already see in the inspector
    }
}
