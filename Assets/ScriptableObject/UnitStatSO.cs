using UnityEngine;

public class UnitStat
{
    public float maxHealth;
    public float attackDamage;
    public float defense;
    public float attackRange;
    public float attackSpeed;
    public float moveSpeed;
}

[CreateAssetMenu(fileName = "UnitStat", menuName = "Stats/UnitStat")]
public class UnitStatSO : ScriptableObject
{
    [Header("Base Stats")]
    public float baseMaxHealth;
    public float baseAttackDamage;
    public float baseAttackRange;
    public float baseAttackSpeed;
    public float baseDefense;
    public float baseMoveSpeed;

    [Header("Growth Per Level / Stage")]
    public float healthPerLevel;
    public float attackPerLevel;
    public float defensePerLevel;

    public UnitStat GetStatByLevel(int level)
    {
        return new UnitStat
        {
            maxHealth = baseMaxHealth + healthPerLevel * level,
            attackDamage = baseAttackDamage + attackPerLevel * level,
            defense = baseDefense + defensePerLevel * level,
            attackRange = baseAttackRange,
            attackSpeed = baseAttackSpeed,
            moveSpeed = baseMoveSpeed,
        };
    }
}
