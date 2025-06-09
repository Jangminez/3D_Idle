using UnityEngine;

[CreateAssetMenu(menuName = "Stats/PlayerStat")]
public class PlayerStatSO : UnitStatSO
{
    [Header("Required Exp")]
    [SerializeField] int baseRequiredExp;
    [SerializeField] int requiredExpPerLevel;

    public int GetRequiredExp(int level)
    {
        return baseRequiredExp + requiredExpPerLevel * level;
    }
}
