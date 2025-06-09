using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : UnitBase
{
    [SerializeField] PlayerStatSO playerStatSO;

    private List<Monster> monsters;

    private int currentLevel = 1;
    private int currentExp = 0;
    private int requiredExp;
    private int currentGold;

    protected override void Start()
    {
        statSO = playerStatSO;
        requiredExp = playerStatSO.GetRequiredExp(currentLevel);
        unitStat = playerStatSO.GetStatByLevel(currentLevel);

        monsters = FindObjectsOfType<Monster>().ToList();

        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (Target == null)
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
