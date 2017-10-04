using UnityEngine;

public class StraightLineBullet : BaseBullet
{
    // Move the bullet in straight line to the shoot direction
    protected override void Move()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}