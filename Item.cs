using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Item
{
    private int id;
    private string name;
    private string description;
    private float weight;

    public int ID => id;
    public string Name => name;
    public string Description => description;
    public float Weight => weight;

    public Item(int id, string name, string desc, float weight)
    {
        this.id = id;
        this.name = name;
        this.description = desc;
        this.weight = weight;
    }

    public Item GetAsItem()
    {
        return (Item)this;
    }

}

public class InventoryItem : Item
{
    private int amount;

    public int Amount => amount;


    public InventoryItem(int ID, string name, string desc, float weight, int amount) : base (ID, name, desc, weight)
    {
        this.amount = Mathf.Abs(amount);
    }

    public InventoryItem(Item item, int amount) : base(item.ID, item.Name, item.Description, item.Weight)
    {
        this.amount = Mathf.Abs(amount);
    }


    public bool AddAmount(int amount = 1)
    {
        amount = Mathf.Abs(amount);

        this.amount += amount;
        return true;
    }

    public bool RemoveAmount(int amount = 1)
    {
        amount = Mathf.Abs(amount);

        if (this.amount - amount >= 0)
        {
            this.amount -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public InventoryItem GetAsInventoryItem()
    {
        return (InventoryItem)this;
    }
}

public class SaleItem : Item
{
    private float price;

    public float Price => Mathf.Abs(price);


    public SaleItem(int ID, string name, string desc, float weight, float price) : base (ID, name, desc, weight)
    {
        this.price = Mathf.Abs(price);
    }

    public SaleItem(Item item, float price): base(item.ID, item.Name, item.Description, item.Weight)
    {
        this.price = Mathf.Abs(price);
    }


    public SaleItem GetAsSaleItem()
    {
        return (SaleItem)this;
    }

    public InventoryItem Take(int amount = 1)
    {
        amount = Mathf.Abs(amount);
        InventoryItem returnItem = new InventoryItem((Item)this, amount);
        return returnItem;
    }
}



[System.Serializable]
public class ItemsJSON
{
    public ItemJSON[] items;
}

[System.Serializable]
public class ItemJSON
{
    public int id;
    public string name;
    public string description;
    public float weight;
}