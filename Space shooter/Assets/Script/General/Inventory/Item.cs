using UnityEngine;

public abstract class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public ItemSlot slot;

    public abstract void Use();
}