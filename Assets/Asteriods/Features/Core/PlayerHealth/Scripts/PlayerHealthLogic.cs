using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthLogic : MonoBehaviour, IDamageable
{
    #region Fields

    [SerializeField] private PlayerHealthModel config;
    [SerializeField] private int currentHealth;
    public static event Action<int> OnHealthChange;

    #endregion

    #region Monobehaviour callbacks

    // Start is called before the first frame update
    void OnEnable()
    {
        currentHealth = config.initHealth;
    }

    #endregion

    #region Methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.TryGetComponent(out IDammager damager))
        {
            if (damager.CanDammagePlayer)
                OnGettingDamage(damager.Damage);
        }

        if (other.transform.parent.TryGetComponent(out IDamageable damageable))
        {
            damageable.OnGettingDamage(1);
        }
    }

    public void OnGettingDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        OnHealthChange?.Invoke(currentHealth);

        if (currentHealth <= 0)
            OnDie();
        else
        {
        }
    }

    public void OnDie()
    {
        gameObject.SetActive(false);
    }

    #endregion
}