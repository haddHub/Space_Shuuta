using UnityEngine;

public abstract class BaseWeapon : ScriptableObject 
{
    public Sprite icon;
	public string weaponName;
    public int damage;
    public float cooldown;
    public GameObject bullet;

    public abstract void Initialize(IShooterController sc);
    public abstract void Use();
}