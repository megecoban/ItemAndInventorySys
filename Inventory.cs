using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<InventoryItem> inventoryItems = new List<InventoryItem>();

    public float TotalWeightOfInventory => GetInventoryWeight();
    

    public void AddItem(InventoryItem item)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].ID == item.ID)
            {
                inventoryItems[i].AddAmount(item.Amount);
                return;
            }
        }
        inventoryItems.Add(item);
    }

    public void RemoveItemAmount(int itemID, int amount)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].ID == itemID)
            {
                inventoryItems[i].RemoveAmount(amount);
                break;
            }
        }
    }

    public InventoryItem RemoveItem(int itemID)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].ID == itemID)
            {
                InventoryItem temp = inventoryItems[i];
                inventoryItems.RemoveAt(i);
                return temp;
            }
        }

        return null;
    }

    public List<InventoryItem> GetAllItems()
    {
        return inventoryItems;
    }

    public InventoryItem GetItemAt(int index)
    {
        return inventoryItems[index];
    }

    public float GetInventoryWeight()
    {
        float returnVal = 0f;

        for(int i = 0;i < inventoryItems.Count;i++)
        {
            returnVal += inventoryItems[i].Weight * inventoryItems[i].Amount;
        }

        return returnVal;
    }

    public void CheckAndArrange()
    {
        for(int i = 0; i<inventoryItems.Count; i++)
        {
            for (int k = 0; k < inventoryItems.Count; k++)
            {
                if (i == k)
                {
                    continue;
                }
                else
                {
                    if (inventoryItems[i].ID == inventoryItems[k].ID && i != k)
                    {
                        inventoryItems[i].AddAmount(inventoryItems[k].Amount);
                        inventoryItems[k].RemoveAmount(inventoryItems[k].Amount);
                    }
                }
            }
        }

        RemoveIfEmpty();
    }

    private void RemoveIfEmpty()
    {
        for(int i=inventoryItems.Count-1;i>=0;i--)
        {
            if(inventoryItems[i].Amount <= 0)
            {
                inventoryItems.RemoveAt(i);
            }
        }
    }
}
