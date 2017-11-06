using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseBullet : MonoBehaviour 
{
    [SerializeField]
    protected float moveSpeed;
    protected Vector3 direction;
    [SerializeField]
    private GameObject impactEffect;

    public delegate void HitSomethingDelegate(Collider2D collision, BaseBullet sender);
    public event HitSomethingDelegate HitSomething;

    protected abstract void Move();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Map Bondary" || collision.gameObject.tag == "Bullet")
            return;

        HitSomething?.Invoke(collision, this);
    }

    private void Update()
    {
        Move();
    }

    private void RotateToDirection()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
        direction.Normalize();
        RotateToDirection();
    }

    public void CollideEffect()
    {
        if (impactEffect != null)
        {
            // adding third the direction to make the impact more on the enemy and not on the edge
            GameObject impact = Instantiate(impactEffect, transform.position + (direction / 3f), Quaternion.identity);
            Destroy(impact, 1f); 
        }
        Destroy(gameObject);
    }
}