using UnityEngine;

public abstract class BaseWeapon : Item
{
    public int damage;
    public float cooldown;
    public GameObject bullet;

    public abstract void Initialize(IShooterController sc);
    public abstract void Fire();

    public override void Use()
    {
        Debug.Log($"{itemName} use !");
    }
}