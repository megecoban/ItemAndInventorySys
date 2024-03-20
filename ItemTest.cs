using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        List<Item> myItems = ItemDatabank.Instance.GetAllItems();
        foreach (Item item in myItems)
        {
            Debug.Log(item.ID + " - "+item.Name+", "+item.Description+" (Weight: "+item.Weight+")");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
