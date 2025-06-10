using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [Header("StageData")]
    [SerializeField] private List<StageData> stageDataList;
    private Dictionary<int, StageData> stageDataDict;

    [Header("MonsterData")]
    [SerializeField] private List<Monster> monsterDataList;
    private Dictionary<string, Monster> monsterDataDict;

    [Header("ItemData")]
    [SerializeField] private List<ItemData> itemDataList;
    private Dictionary<int, ItemData> itemDataDict;

    void Awake()
    {
        stageDataDict = new Dictionary<int, StageData>();

        foreach (var stage in stageDataList)
        {
            stageDataDict.Add(stage.stageKey, stage);
        }

        monsterDataDict = new Dictionary<string, Monster>();

        foreach (var monster in monsterDataList)
        {
            monsterDataDict.Add(monster.name, monster);
        }

        itemDataDict = new Dictionary<int, ItemData>();

        foreach (var item in itemDataList)
        {
            itemDataDict.Add(item.itemKey, item);
        }
    }

    public StageData GetStageDataByStageKey(int stageKey)
    {
        if (stageDataDict.ContainsKey(stageKey))
        {
            return stageDataDict[stageKey];
        }

        return null;
    }

    public Monster GetMonsterByType(string type)
    {
        if (monsterDataDict.ContainsKey(type))
        {
            return monsterDataDict[type];
        }

        return null;
    }

    public ItemData GetItemByKey(int key)
    {
        if (itemDataDict.ContainsKey(key))
        {
            return itemDataDict[key];
        }

        return null;
    }
}
