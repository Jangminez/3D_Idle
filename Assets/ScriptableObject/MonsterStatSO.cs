using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/MonsterStat")]
public class MonsterStatSO : UnitStatSO
{
    [Header("Drop Gold & Exp")]
    public int baseGoldDrop;
    public int goldPerStage;
    public int baseExpDrop;
    public int expPerStage;

    public int GetGoldRop(int stage)
    {
        return baseGoldDrop + stage * goldPerStage;
    }

    public int GetExpDrop(int stage)
    {
        return baseExpDrop * stage * expPerStage;
    }
}
