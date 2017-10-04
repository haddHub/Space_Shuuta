using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Normal Weapon")]
public class NormalWeapon : BaseWeapon
{
    private IShooterController shooterController;

    public override void Initialize(IShooterController bsc)
    {
        shooterController = bsc;
    }

    public override void Use()
    {
        shooterController?.Fire();
    }
}