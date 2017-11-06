using UnityEngine;

public class EnemyManager : BaseCharacter
{
    [SerializeField]
    private int score = 5;

    public override void Die()
    {
        GameManager.instance?.AddPointToScore(score);
        Destroy(gameObject);
    }
}