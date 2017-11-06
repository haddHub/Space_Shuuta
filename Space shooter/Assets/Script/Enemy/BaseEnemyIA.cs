using UnityEngine;

[RequireComponent(typeof(IShooterController))]
public abstract class BaseEnemyIA : MonoBehaviour 
{
    [SerializeField]
    protected float moveSpeed;

    protected IShooterController sc;

    protected abstract void Move();
    protected abstract void Shoot();
    private void Awake()
    {
        sc = GetComponent<IShooterController>();
    }

    private void Update()
    {
        Think();
    }

    protected virtual void Think()
    {
        Move();
        Shoot();
    }
}