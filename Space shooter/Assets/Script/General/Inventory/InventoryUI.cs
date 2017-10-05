using UnityEngine;

public class InventoryUI : MonoBehaviour 
{
    private Inventory inventory;
    private InventorySlot[] slots;

    public void Initialize()
    {
        Debug.Log("Inventory UI start");
        inventory = Inventory.instance;
        inventory.InventoryChangedEvent += UpdateUI;
        slots = transform.GetComponentsInChildren<InventorySlot>();
    }

    private void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.GetItems().Count)
            {
                slots[i].AddItem(inventory.GetItems()[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public void ShowOrHideInventory()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}