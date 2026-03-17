using UnityEngine;

public class EnemyHealth : Health
{
    public static int LivingEnemyCount = 0;

    protected override void Awake()
    {
        base.Awake();
        LivingEnemyCount++;
    }

    protected override void Die()
    {
        LivingEnemyCount--;

        Destroy(gameObject); // chết là biến mất
    }
}