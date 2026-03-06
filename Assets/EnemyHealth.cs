using UnityEngine;

public class EnemyHealth : Health
{
    public static int LivingEnemyCount = 0;

    private void Awake()
    {
        LivingEnemyCount++;
    }

    protected override void Die()
    {
        LivingEnemyCount--;
        base.Die();
    }
}