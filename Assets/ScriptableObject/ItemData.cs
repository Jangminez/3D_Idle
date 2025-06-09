using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/New ItemData")]
public class ItemData : ScriptableObject
{
    public int itemKey;
    public EquipType equipType;
    public List<StatEntry> stats;
}

public class StatEntry
{
    StatType statType;
    float value;
}
