using UnityEngine;

public class EnemyManager : BaseCharacter
{
    public override void Die()
    {
        Destroy(gameObject);
    }
}