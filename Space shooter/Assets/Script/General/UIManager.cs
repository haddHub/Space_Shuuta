using UnityEngine;

public class UIManager : MonoBehaviour 
{
    [SerializeField]
    private InventoryUI inventoryUI;

    private void Start()
    {
        inventoryUI.Initialize();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventoryUI.ShowOrHideInventory();
    }
}