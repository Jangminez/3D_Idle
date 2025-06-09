using UnityEngine;

[CreateAssetMenu(menuName = "Stats/PlayerStat")]
public class PlayerStatSO : UnitStatSO
{
    [Header("Required Exp")]
    [SerializeField] int baseRequiredExp;
    [SerializeField] int requiredExpPerLevel;

    public int GetRequiredExp(int level)
    {
        int multiplier = level - 1 <= 0 ? 0 : level - 1;

        return baseRequiredExp + requiredExpPerLevel * multiplier;
    }
}
