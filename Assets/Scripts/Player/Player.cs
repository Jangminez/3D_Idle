using System.Collections.Generic;
using UnityEngine;

public class Player : UnitBase
{
    [SerializeField] PlayerStatSO playerStatSO;

    private List<Monster> monsters = new List<Monster>();

    private int currentLevel = 1;
    private int currentExp = 0;
    private int requiredExp;
    private int currentGold;

    public override void Init(int level)
    {
        currentLevel = level;

        statSO = playerStatSO;
        requiredExp = playerStatSO.GetRequiredExp(currentLevel);
        unitStat = playerStatSO.GetStatByLevel(currentLevel);

        base.Init(level);

    }

    protected override void Update()
    {
        base.Update();

        if (Target == null && monsters != null)
        {
            FindNextTarget();
        }
    }

    public override void Attack()
    {
        base.Attack();

        if (Target.TryGetComponent(out IDamgeable damgeable))
        {
            damgeable.TakeDamage(unitStat.attackDamage);
        }
    }

    public void SetMonsters(List<Monster> monsters)
    {
        this.monsters = monsters;
    }

    public void GetReward(int gold, int exp)
    {
        currentExp += exp;
        currentGold += gold;

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
