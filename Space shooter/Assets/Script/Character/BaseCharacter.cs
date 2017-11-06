using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour, IDamageable
{
    protected int health;
    [SerializeField]
    protected int maxHealth;

    private void Start()
    {
        health = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;
            Die();
        }
        //Animation damaged
    }

    public abstract void Die();
}