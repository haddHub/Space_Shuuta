using UnityEngine;

public class DiagonalEnemyIA : BaseEnemyIA
{
    private float sideDirection;
    private float diagonalOffset;

    private void Start()
    {
        if (transform.position.y == 0)
        {
            int side = Random.Range(0, 2);
            if (side == 0)
                sideDirection = 1f;
            else
                sideDirection = -1f;
        }
        else if (transform.position.y < 0)
            sideDirection = 1f;
        else
            sideDirection = -1f;


            diagonalOffset = Random.Range(2f, 3.1f);
    }

    protected override void Move()
    {
        transform.position += (-transform.up + sideDirection * (transform.right / diagonalOffset)) * moveSpeed * Time.deltaTime;
    }

    protected override void Shoot()
    {
        if (sc != null)
            sc.Fire();
    }
}