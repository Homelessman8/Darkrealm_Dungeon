using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    //define as singleton
    public static ItemSpawnManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] GameObject pickupItemPrefab;

    //Method accepts position, item and count of items
    public void SpawnItem(Vector3 position, Item item, int count)
    {
        GameObject o = Instantiate(pickupItemPrefab, position, Quaternion.identity);
        o.GetComponent<PickUpItem>().Set(item, count);
    }

}
