using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
    [SerializeField]
    private int space;
    private List<Item> items = new List<Item>();

    public static Inventory instance;

    public delegate void onInventoryChanged();
    public event onInventoryChanged InventoryChangedEvent;

    private void Awake()
    {
        instance = this;
    }

    public bool AddItem(Item newItem)
    {
        if (items.Count < space)
        {
            items.Add(newItem);
            Debug.Log($"{newItem.itemName} added to the inventory");
            InventoryChangedEvent?.Invoke();
            return true;
        }
        else
        {
            Debug.Log($"Not enough room to add {newItem.itemName}");
            return false;
        }
    }

    public void RemoveItem(Item oldItem)
    {
        if (items.Contains(oldItem))
        {
            items.Remove(oldItem);
            InventoryChangedEvent?.Invoke();
        }
    }

    public List<Item> GetItems() => items;
}