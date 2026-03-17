using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyWave[] enemyWaves;

    private int currentWave = 0;

    void Start()
    {
        SpawnEnemyWave();
    }

    private void SpawnEnemyWave()
    {
        var waveInfo = enemyWaves[currentWave];

        Vector3 startPosition = waveInfo.flyPath[0];

        for (int i = 0; i < waveInfo.numberOfEnemy; i++)
        {
            var enemy = Instantiate(
                waveInfo.enemyPrefab,
                startPosition,
                Quaternion.identity
            );

            var agent = enemy.GetComponent<FlyPathAgent>();

            if (agent != null)
            {
                agent.flyPath = waveInfo.flyPath;
                agent.flySpeed = waveInfo.speed;
            }

            startPosition += waveInfo.formationOffset;
        }

        currentWave++;

        if (currentWave < enemyWaves.Length)
        {
            Invoke(nameof(SpawnEnemyWave), waveInfo.nextWaveDelay);
        }
    }

    // ⭐ thêm hàm này
    public bool AllWavesSpawned()
    {
        return currentWave >= enemyWaves.Length;
    }
}