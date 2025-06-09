using System.Collections.Generic;
using UnityEngine;

public class Player : UnitBase, IDamgeable
{
    [SerializeField] PlayerStatSO playerStatSO;
    private List<Monster> monsters = new List<Monster>();

    private int currentLevel = 1;
    private int currentExp = 0;
    private int requiredExp;
    private int currentGold;

    private float bonusHealth = 0f;
    private float bonusAttackDamage = 0f;
    private float bonusDefense = 0f;
    private float bonusAttackSpeed = 0f;

    private float TotalMaxHealth => unitStat.maxHealth + bonusHealth;
    private float TotalAttackDamage => unitStat.attackDamage + bonusAttackDamage;
    private float TotalDefense => unitStat.defense + bonusDefense;
    private float TotalAttackSpeed => unitStat.attackSpeed + bonusAttackSpeed;

    private PlayerEventHandler playerEvent;
    public PlayerEventHandler Events { get => playerEvent; }

    protected override void Awake()
    {
        base.Awake();

        playerEvent = new PlayerEventHandler();
    }

    public override void Init(int level)
    {
        currentLevel = level;

        statSO = playerStatSO;
        requiredExp = playerStatSO.GetRequiredExp(currentLevel);
        unitStat = playerStatSO.GetStatByLevel(currentLevel);

        base.Init(level);

        InitRaiseEvents();
    }

    protected override void Update()
    {
        base.Update();

        if (Target == null && monsters != null)
        {
            FindNextTarget();
        }
    }

    void InitRaiseEvents()
    {
        playerEvent.RaiseLevelChanged(currentLevel);
        playerEvent.RaiseGoldChanged(currentGold);
        playerEvent.RaiseExpChanged(currentExp, requiredExp);
    }

    public override void Attack()
    {
        base.Attack();

        if (Target.TryGetComponent(out IDamgeable damgeable))
        {
            damgeable.TakeDamage(TotalAttackDamage);
        }
    }
    public void TakeDamage(float damage)
    {
        float finalDamage = damage - TotalDefense > 0 ? damage - TotalDefense : 1;
        currentHealth -= finalDamage;

        onHealthChanged?.Invoke(currentHealth, TotalMaxHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void SetMonsters(List<Monster> monsters)
    {
        this.monsters = monsters;
    }

    public void GetReward(int gold, int exp)
    {
        currentGold += gold;
        currentExp += exp;

        playerEvent.RaiseGoldChanged(currentGold);
        playerEvent.RaiseExpChanged(currentExp, requiredExp);

        LevelUp();
    }

    private void LevelUp()
    {
        while (currentExp >= requiredExp)
        {
            currentLevel++;
            currentExp -= requiredExp;

            unitStat = playerStatSO.GetStatByLevel(currentLevel);
            requiredExp = playerStatSO.GetRequiredExp(currentLevel);

            playerEvent.RaiseLevelChanged(currentLevel);
            playerEvent.RaiseExpChanged(currentExp, requiredExp);
        }
    }

    private void FindNextTarget()
    {
        monsters.RemoveAll(m => m == null);

        float minDistance = float.MaxValue;
        Transform nearMonster = null;

        foreach (var monster in monsters)
        {
            if (monster == null)
            {
                monsters.Remove(monster);
                continue;
            }

            float distance = Vector3.Distance(transform.position, monster.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearMonster = monster.transform;
            }
        }

        if (nearMonster != null)
            Target = nearMonster;
    }
}
