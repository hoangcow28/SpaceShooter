using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int defaultHealthPoint = 3;

    public System.Action onDead;
    public System.Action onHealthChanged;

    public int healthPoint;

    private bool canTakeDamage = false;

    protected virtual void Awake()
    {
        // reset máu ngay khi spawn
        healthPoint = defaultHealthPoint;
    }

    private void Start()
    {
        // cập nhật thanh máu
        onHealthChanged?.Invoke();

        // tránh bị trúng đạn ngay khi spawn
        Invoke(nameof(EnableDamage), 0.2f);
    }

    void EnableDamage()
    {
        canTakeDamage = true;
    }

    public void TakeDamage(int damage)
    {
        if (!canTakeDamage) return;
        if (healthPoint <= 0) return;

        healthPoint -= damage;

        onHealthChanged?.Invoke();

        if (healthPoint <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        if (explosionPrefab != null)
        {
            var explosion = Instantiate(
                explosionPrefab,
                transform.position,
                transform.rotation
            );

            Destroy(explosion, 1f);
        }

        onDead?.Invoke();

        Destroy(gameObject);
    }
}