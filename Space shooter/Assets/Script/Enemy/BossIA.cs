using UnityEngine;

public class BossIA : BaseEnemyIA
{
    protected override void Move()
    {
        if(transform.position.y > 2)
            transform.position += -transform.up * moveSpeed * Time.deltaTime;
    }

    protected override void Shoot()
    {
        if (sc != null)
            sc.Fire();
    }
}