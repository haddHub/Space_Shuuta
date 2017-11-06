using UnityEngine;

public class StraightLineEnemyIA : BaseEnemyIA
{
    protected override void Move()
    {
        transform.position += -transform.up * moveSpeed * Time.deltaTime;
    }

    protected override void Shoot()
    {
        if (sc != null)
            sc.Fire();
    }
}