using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour 
{
    private Item item;
    [SerializeField]
    private Image icon;
    [SerializeField]
    private Button buton;


    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.itemIcon;
        icon.enabled = true;
        buton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        buton.interactable = false;
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }
}