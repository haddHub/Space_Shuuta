using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShooterController : MonoBehaviour, IShooterController
{
    [SerializeField]
    private BaseWeapon weapon;
    private float timeBeforeShooting = 0f;
    [SerializeField]
    private Transform weaponSlot1;
    private EquipementManager equipement;

    private void Start()
    {
        equipement = EquipementManager.instance;
        equipement.EquipementChangedEvent += NewEquipement;
        weapon?.Initialize(this); // the player can start with a weapon without the equipement system
    }

    private void NewEquipement()
    {
        Item newWeapon = equipement.GetItem()[(int)ItemSlot.mainWeapon];
        if (newWeapon == null)
            weapon = null;
        else
        {
            weapon = newWeapon as BaseWeapon;
            weapon.Initialize(this);
        }
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (weapon != null)
        {
            timeBeforeShooting -= Time.deltaTime;

            if (Input.GetMouseButtonDown(0) && timeBeforeShooting <= 0f)
            {
                weapon.Fire();
                timeBeforeShooting = weapon.cooldown;
            }
        }
    }

    public void Fire()
    {
        // Instantiate weapon bullet
        GameObject newBulletGo = Instantiate(weapon.bullet, weaponSlot1.position, Quaternion.identity, transform.parent);
        newBulletGo.SetActive(false);
        BaseBullet newBullet = newBulletGo.GetComponent<BaseBullet>();

        newBullet.SetDirection(weaponSlot1.position - transform.position);

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