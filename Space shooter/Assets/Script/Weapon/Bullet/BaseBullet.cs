using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseBullet : MonoBehaviour 
{
    [SerializeField]
    protected float moveSpeed;
    protected Vector3 direction;

    public delegate void HitSomethingDelegate(Collider2D collision, BaseBullet sender);
    public event HitSomethingDelegate HitSomething;

    protected abstract void Move();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Map Bondary")
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
        Destroy(gameObject);
    }
}