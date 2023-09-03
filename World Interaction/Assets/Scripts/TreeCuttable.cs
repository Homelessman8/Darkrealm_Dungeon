using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] float spread = 0.7f;

    [SerializeField] Item item;
    [SerializeField] int itemCountInOneDrop = 1;
    [SerializeField] int dropCount = 5;

    public override void Hit()
    {
        while (dropCount > 0)
        {
            dropCount -= 1;

            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject go = Instantiate(pickUpDrop);
            go.GetComponent<PickUpItem>().Set(item, itemCountInOneDrop);
            go.transform.position = position;

            // Set the layer of the instantiated object to "Background". If error about too many layers persist, comment line
            // go.layer = LayerMask.NameToLayer("Background");

            // Set the sorting order to 1. Only comment for older versions of unity
            Renderer renderer = go.GetComponent<Renderer>();
            if (renderer == null)
            {
                continue;
            }
            renderer.sortingOrder = 1;
        }

        Destroy(gameObject);
    }
}
