using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/New ItemData")]
public class ItemData : ScriptableObject
{
    public int itemKey;
    public string itemName;
    public Sprite itemIcon;
    public EquipType equipType;
    public List<StatEntry> stats;
    [TextArea(3, 5)]
    public string description;

    public bool isConsumable;
    public bool isTemporary;
    public float duration;
}

[System.Serializable]
public class StatEntry
{
    public StatType statType;
    public float value;
}
