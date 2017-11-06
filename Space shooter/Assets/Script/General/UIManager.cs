using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
    [SerializeField]
    private InventoryUI inventoryUI;
    [SerializeField]
    private EquipementUI equipementUI;
    [SerializeField]
    private Text score;

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

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

    public void UpdateScore(int newScore)
    {
        score.text = newScore.ToString();
    }
}