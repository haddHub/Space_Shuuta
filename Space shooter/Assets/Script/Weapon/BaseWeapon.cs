using UnityEngine;

public abstract class BaseWeapon : ScriptableObject 
{
	public string weaponName;

    public abstract void Initialize(GameObject obj);
}