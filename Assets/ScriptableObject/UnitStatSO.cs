using UnityEngine;

public class UnitStat
{
    public float maxHealth;
    public float attackDamage;
    public float defense;
    public float attackRange;
    public float attackSpeed;
    public float moveSpeed;
    public float chaseRange;
}

public class UnitStatSO : ScriptableObject
{
    [Header("Base Stats")]
    [SerializeField] float baseMaxHealth;
    [SerializeField] float baseAttackDamage;
    [SerializeField] float baseAttackRange;
    [SerializeField] float baseAttackSpeed;
    [SerializeField] float baseDefense;
    [SerializeField] float baseMoveSpeed;
    [SerializeField] float baseChaseRange;

    [Header("Growth Per Level / Stage")]
    [SerializeField] float healthPerLevel;
    [SerializeField] float attackPerLevel;
    [SerializeField] float defensePerLevel;

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
            chaseRange = baseChaseRange
        };
    }
}
