using UnityEngine;

public class UIManager : MonoBehaviour 
{
    [SerializeField]
    private InventoryUI inventoryUI;
    [SerializeField]
    private EquipementUI equipementUI;

    private void Start()
    {
        inventoryUI.Initialize();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.ShowOrHideInventory();
            equipementUI.ShowOrHideEquipement();
        }
    }
}