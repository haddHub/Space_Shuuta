using UnityEngine;

public class EquipementUI : MonoBehaviour 
{
    private EquipementManager equipement;
    private EquipementSlot[] slots;

    private void Start()
    {
        equipement = EquipementManager.instance;
        equipement.EquipementChangedEvent += UpdateUI;
        slots = transform.GetComponentsInChildren<EquipementSlot>();
    }

    private void UpdateUI()
    {

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < equipement.GetItemCount())
            {
                slots[i].AddItem(equipement.GetItem()[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public void ShowOrHideEquipement()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}