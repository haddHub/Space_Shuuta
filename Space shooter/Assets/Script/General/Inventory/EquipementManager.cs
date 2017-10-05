using System.Collections.Generic;
using UnityEngine;

public class EquipementManager : MonoBehaviour 
{
    private BaseWeapon[] currentEquipement;

    public static EquipementManager instance;

    public delegate void NewEquipementDelegate(BaseWeapon weapon, WeaponSlot slot);
    public event NewEquipementDelegate NewEquipement;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentEquipement = new BaseWeapon[2];
    }

    public void EquipWeapon(BaseWeapon weapon, WeaponSlot slot)
    {
        currentEquipement[(int)slot] = weapon;
        NewEquipement?.Invoke(weapon, slot);
    }
}

public enum WeaponSlot
{
    Slot1 = 0,
    Slot2 = 1
}