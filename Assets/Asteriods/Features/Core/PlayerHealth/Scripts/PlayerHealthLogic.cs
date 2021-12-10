using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerHealthLogic : MonoBehaviour, IDamageable
{
    #region Fields

    [SerializeField] private PlayerHealthModel config;
    [SerializeField] private int currentHealth;
    public static event Action<int> OnHealthChange;
    public static event Action<GameObject> OnRespawn;
    private bool isInvulnarable;
    [SerializeField] SpriteRenderer shipRenderer;
    public static event Action OnGameEnd;
    #endregion

    #region  Properties

    public int CurrentHealth
    {
        get => currentHealth;
    }

    public int GetMaxhHealth
    {
        get => config.initHealth;
    }

    #endregion
    #region Monobehaviour callbacks

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = config.initHealth;
    }

    private void OnEnable()
    {
        StartCoroutine(InvulnrableCourutine());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(isInvulnarable)
            return;
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
    #endregion

    #region Methods



    public void OnGettingDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        OnHealthChange?.Invoke(currentHealth);
        ObjectPool.Instantiate(config.explosionPrefab, transform.position, Quaternion.identity);
        if (currentHealth <= 0)
            OnDie();
        else
        {
            MainContainer.AstroidGenerator.ClearAllAStroids();
            OnRespawn?.Invoke(gameObject);
        }
    }

    public void OnDie()
    {
        OnGameEnd?.Invoke();
        gameObject.SetActive(false);
    }

    #endregion

    #region  Coroutines

    IEnumerator InvulnrableCourutine()
    {
        isInvulnarable = true;
        var period = config.invulnarablePeriod;
        var time = 0.0f;
        var fadePeriod = .1f;
        var delay=new WaitForSeconds(fadePeriod);
        while (time<period)
        {
            shipRenderer.DOFade(0, fadePeriod);
            yield return delay;
            shipRenderer.DOFade(1, fadePeriod);
            yield return delay;
            time += 2 * fadePeriod;
        }

        var colour = shipRenderer.color;
        colour.a = 1;
        shipRenderer.color = colour;
        isInvulnarable = false;
    }

    #endregion
}