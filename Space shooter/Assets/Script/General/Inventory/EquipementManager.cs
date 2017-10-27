using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EquipementManager : MonoBehaviour
{
    [SerializeField]
    private Item[] equipedItem;
    //Other item

    public static EquipementManager instance;

    public delegate void onEquipementChanged();
    public event onEquipementChanged EquipementChangedEvent;

    private void Awake()
    {
        instance = this;
        equipedItem = new Item[Enum.GetNames(typeof(ItemSlot)).Length];
    }

    public void EquipeItem(Item newItem)
    {
        Debug.Log("Equiped" + newItem.itemName);
        int slot = (int)newItem.slot;
        UnEquipeItem(equipedItem[slot]);
        equipedItem[slot] = newItem;

        EquipementChangedEvent?.Invoke();
    }

    public void UnEquipeItem(Item oldItem)
    {
        if (oldItem != null)
        {
            int slot = (int)oldItem.slot;
            if (equipedItem[slot] != null)
            {
                equipedItem[slot] = null;
                Inventory.instance?.AddItem(oldItem);

                EquipementChangedEvent?.Invoke();
            }
        }
    }

    public Item[] GetItem() => equipedItem;

    public int GetItemCount()
    {
        return equipedItem.Count(i => i != null);
    }
}

public enum ItemSlot
{
    mainWeapon,
    other
}