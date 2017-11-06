using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;

    [SerializeField]
    private WaveSpawner waveSpawner;
    [SerializeField]
    private AnimationCurve difficultyCurve;

    [SerializeField]
    private int scoreToSpawnBoss = 200;
    private int score = 0;
    [SerializeField]
    private float levelMaximumTime = 60;
    private float levelTimeElapsed = 0f;

    private GamePhase phase = GamePhase.Enemies;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if(waveSpawner != null)
            StartCoroutine(SpawnRandomEnemy());
    }

    private void Update()
    {
        levelTimeElapsed += Time.deltaTime;
    }

    IEnumerator SpawnRandomEnemy()
    {
        while (phase == GamePhase.Enemies)
        {
            float difficulty = GetDifficultyLevel();
            int enemyCount = ((int)difficultyCurve.Evaluate(difficulty));
            waveSpawner?.SpawnRandomEnemies(enemyCount);
            yield return new WaitForSeconds(2);
        }
    }

    private float GetDifficultyLevel()
    {
        return Mathf.Clamp01(levelTimeElapsed / levelMaximumTime);
    }

    public void AddPointToScore(int point)
    {
        score += point;
        UIManager.instance.UpdateScore(score);

        if (score >= scoreToSpawnBoss && phase == GamePhase.Enemies)
        {
            phase = GamePhase.Boss;
            SpawnBoss();
        }
    }

    private void SpawnBoss()
    {
        waveSpawner?.SpawnBoss();
        //Lancer la cut scene
    }
}

public enum GamePhase
{
    Enemies,
    Boss
}