using UnityEngine;

public class PlayerShooterController : MonoBehaviour, IShooterController
{
    [SerializeField]
    private BaseWeapon weapon;
    private float timeBeforeShooting = 0f;
    [SerializeField]
    private Transform shootingPosition;

    private void Start()
    {
        weapon?.Initialize(this);
    }

    private void Update()
    {
        if (weapon != null)
        {
            timeBeforeShooting -= Time.deltaTime;

            if (Input.GetMouseButtonDown(0) && timeBeforeShooting <= 0f)
            {
                weapon.Use();
                timeBeforeShooting = weapon.cooldown;
            }
        }
    }

    public void Fire()
    {
        // Instantiate weapon bullet
        GameObject newBulletGo = Instantiate(weapon.bullet, shootingPosition.position, Quaternion.identity, transform.parent);
        newBulletGo.SetActive(false);
        BaseBullet newBullet = newBulletGo.GetComponent<BaseBullet>();

        newBullet.SetDirection(shootingPosition.position - transform.position);

        newBullet.HitSomething += BulletHasHitSomething;
        newBulletGo.SetActive(true);
    }

    private void BulletHasHitSomething(Collider2D collision, BaseBullet sender)
    {
        if (collision.gameObject == gameObject)
            return;
        
        sender.CollideEffect();

        // Aplly weapon damage to the object my bullet collided with
        collision.GetComponent<IDamageable>()?.TakeDamage(weapon.damage);
    }
}