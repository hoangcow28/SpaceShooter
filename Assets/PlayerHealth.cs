using UnityEngine;
using System;

public class PlayerHealth : Health
{
    public event Action onDead;

    protected override void Die()
    {
        base.Die();

        if (onDead != null)
        {
            onDead.Invoke();
        }

        Debug.Log("Player died");
    }
}