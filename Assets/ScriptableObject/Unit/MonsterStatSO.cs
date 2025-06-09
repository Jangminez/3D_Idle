using UnityEngine;

[CreateAssetMenu(menuName = "Stats/MonsterStat")]
public class MonsterStatSO : UnitStatSO
{
    [Header("Drop Gold & Exp")]
    public int baseGoldDrop;
    public int baseExpDrop;
    public int goldPerStage;
    public int expPerStage;

    public int GetGoldDrop(int stage)
    {
        int multiplier = stage - 1 <= 0 ? 0 : stage - 1;

        return baseGoldDrop + goldPerStage * multiplier;
    }

    public int GetExpDrop(int stage)
    {
        int multiplier = stage - 1 <= 0 ? 0 : stage - 1;
        
        return baseExpDrop + expPerStage * multiplier;
    }
}
