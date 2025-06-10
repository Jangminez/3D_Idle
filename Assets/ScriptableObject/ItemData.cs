using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/New ItemData")]
public class ItemData : ScriptableObject
{
    [Header("ItemData")]
    public int itemKey;
    public string itemName;
    public Sprite itemIcon;
    public EquipType equipType;
    public StatType statType;
    public float baseValue;
    [TextArea(3, 5)]
    public string description;

    [Header("Upgrade Per Level")]
    public float valuePerUpgradeLevel;
    public int costPerUpgradeLevel;

    [Header("Item Cost")]
    public int itemCost;

    [Header("Item Options")]
    public bool isConsumable;
    public bool isTemporary;
    public float duration;
}


[System.Serializable]
public class ItemUpgradeInfo
{
    public int level;
    public float value;
    public float valuePerUpgradeLevel;
    public int cost;
    public int costPerUpgradeLevel;

    public ItemUpgradeInfo(float valuePerUpgradeLevel, int costPerUpgradeLevel, int level = 1)
    {
        this.level = level;
        this.valuePerUpgradeLevel = valuePerUpgradeLevel;
        this.costPerUpgradeLevel = costPerUpgradeLevel;

        value = 0;
        cost = costPerUpgradeLevel;
    }

    public void Upgrade()
    {
        level++;
        value = GetUpgradeValue(level);
        cost = GetUpgradeCost(level);
    }

    private int GetUpgradeCost(int level)
    {
        int multiplier = level - 1;
        return costPerUpgradeLevel * multiplier;
    }

    private float GetUpgradeValue(int level)
    {
        int multiplier = level - 1;
        return valuePerUpgradeLevel * multiplier;
    }
}
public class ItemInstance
{
    public ItemData ItemData { get; private set; }
    public ItemUpgradeInfo UpgradeInfo { get; private set; }
    public bool IsEquip { get; private set; }
    public bool IsBuy { get; private set; }
    public int Count { get; private set; }
    public ItemInstance(ItemData itemData)
    {
        ItemData = itemData;

        if (!ItemData.isConsumable)
            UpgradeInfo = new ItemUpgradeInfo(ItemData.valuePerUpgradeLevel, ItemData.costPerUpgradeLevel);

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

    public void BuyItem()
    {
        IsBuy = true;
    }
}
