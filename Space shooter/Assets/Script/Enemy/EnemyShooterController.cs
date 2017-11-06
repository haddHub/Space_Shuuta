using UnityEngine;

public class EnemyShooterController : MonoBehaviour, IShooterController
{
    [SerializeField]
    private BaseWeapon weapon;
    private float timeBeforeShooting = 0.5f;
    [SerializeField]
    private Transform weaponSlot;

    public void Fire()
    {
        if (weapon != null)
        {
            if (timeBeforeShooting <= 0f)
            {
                timeBeforeShooting = weapon.cooldown;

                // Instantiate weapon bullet
                GameObject newBulletGo = Instantiate(weapon.bullet, weaponSlot.position, Quaternion.identity, transform.parent);
                newBulletGo.SetActive(false);
                BaseBullet newBullet = newBulletGo.GetComponent<BaseBullet>();

                newBullet.SetDirection(weaponSlot.position - transform.position);

                newBullet.HitSomething += BulletHasHitSomething;
                newBulletGo.SetActive(true);
            }
        }
    }

    private void Start()
    {
        if (weapon != null)
        {
            weapon.Initialize(this);
        }
    }

    private void Update()
    {
        timeBeforeShooting -= Time.deltaTime;
    }

    private void BulletHasHitSomething(Collider2D collision, BaseBullet sender)
    {
        if (collision.gameObject == gameObject || collision.gameObject.tag == "Enemy" || collision.GetComponent<PickupItem>() != null)
            return;

        sender.CollideEffect();

        // Aplly weapon damage to the object my bullet collided with
        collision.GetComponent<IDamageable>()?.TakeDamage(weapon.damage);
    }
}