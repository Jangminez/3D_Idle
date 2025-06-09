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
        return baseGoldDrop + stage * goldPerStage;
    }

    public int GetExpDrop(int stage)
    {
        return baseExpDrop * stage * expPerStage;
    }
}
