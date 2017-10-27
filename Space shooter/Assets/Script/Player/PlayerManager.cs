using UnityEngine;

public class PlayerManager : BaseCharacter
{
    public override void Die()
    {
        Debug.Log("Player dead");
        Destroy(gameObject);
    }
}