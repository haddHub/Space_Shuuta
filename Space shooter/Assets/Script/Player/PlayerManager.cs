using UnityEngine;

public class PlayerManager : BaseCharacter
{
    public override void Die()
    {
        Debug.Log("Player dead");
        Destroy(gameObject);
    }

    public override void TakeDamage(int damage)
    {
        // UI stuff
        base.TakeDamage(damage);
    }
}