using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/New ItemData")]
public class ItemData : ScriptableObject
{
    public int itemKey;
    public string itemName;
    public Sprite itemIcon;
    public EquipType equipType;
    public StatType statType;
    public float baseValue;

    [TextArea(3, 5)]
    public string description;

    public bool isConsumable;
    public bool isTemporary;
    public float duration;
}


[System.Serializable]
public class ItemUpgradeInfo
{
    public int level;
    public float value;
    public int cost;

    public ItemUpgradeInfo(int level = 1)
    {
        this.level = level;
        this.value = 0;
        this.cost = GetUpgradeCost(level);
    }

    public void Upgrade()
    {
        level++;
        value += GetUpgradeValue(level);
        cost = GetUpgradeCost(level);
    }

    private int GetUpgradeCost(int level)
    {
        return 100 + level * 100;
    }

    private float GetUpgradeValue(int level)
    {
        return level * 1.5f;
    }
}
public class ItemInstance
{
    public ItemData ItemData { get; private set; }
    public ItemUpgradeInfo UpgradeInfo { get; private set; }
    public bool IsEquip { get; private set; }
    public int Count { get; private set; }
    public ItemInstance(ItemData itemData)
    {
        ItemData = itemData;

        if (!ItemData.isConsumable)
            UpgradeInfo = new ItemUpgradeInfo();

        IsEquip = false;
    }

    public void EquipItem(bool isEquip)
    {
        IsEquip = isEquip;
    }

    public void Upgrade()
    {
        UpgradeInfo.Upgrade();
    }

    public float GetTotalStatValue()
    {
        return ItemData.baseValue + UpgradeInfo.value;
    }
    public string GetFormattedDescription()
    {
        if (ItemData.isConsumable)
            return string.Format(ItemData.description, ItemData.baseValue * 100);
        else
            return string.Format(ItemData.description, GetTotalStatValue());
    }

    public void AddItem(int count)
    {
        Count += count;
    }

    public bool UseItem()
    {
        bool isEmpty = false;

        if (Count > 0)
        {
            Count--;
            if (Count <= 0)
                isEmpty = true;
        }

        return isEmpty;
    }
}
