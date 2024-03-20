using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemDatabank : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string pathOfItemDatabankJSON = "/MySys/Inventory/itemDatas.json";

    public static ItemDatabank Instance;

    private ItemDatabank instance;

    private List<Item> allItems = new List<Item>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            Instance = instance;
        }

        ReadJSONAndPrepareItems();
    }

    private void ReadJSONAndPrepareItems()
    {
        string path = Application.dataPath + pathOfItemDatabankJSON;

        if (File.Exists(path))
        {
            string jsonString = File.ReadAllText(path);

            ItemsJSON itemsData = JsonUtility.FromJson<ItemsJSON>(jsonString);

            foreach (var item in itemsData.items)
            {
                allItems.Add(new Item(item.id, item.name, item.description, item.weight));
            }
        }
        else
        {
            Debug.LogError("itemDatabank.json dosyasý bulunamadý! " + path);
        }
    }

    public Item GetItemWithID(int id)
    {
        if(allItems==null || allItems.Count==0)
        {
            ReadJSONAndPrepareItems();
        }

        for(int i=0; i<allItems.Count; i++)
        {
            if (allItems[i].ID == id)
            {
                return allItems[i];
            }
        }

        return null;
    }

    public List<Item> GetAllItems()
    {
        if (allItems == null || allItems.Count == 0)
        {
            ReadJSONAndPrepareItems();
        }

        return allItems;
    }
}
