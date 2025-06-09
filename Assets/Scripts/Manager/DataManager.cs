using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [Header("StageData")]
    [SerializeField] private List<StageData> stageDataList;
    private Dictionary<int, StageData> stageDataDict;

    [Header("MonsterData")]
    [SerializeField] private List<Monster> monsterList;
    private Dictionary<string, Monster> monsterDict;

    void Awake()
    {
        stageDataDict = new Dictionary<int, StageData>();

        foreach (var stage in stageDataList)
        {
            stageDataDict.Add(stage.stageKey, stage);
        }

        monsterDict = new Dictionary<string, Monster>();

        foreach (var monster in monsterList)
        {
            monsterDict.Add(monster.name, monster);
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
        if (monsterDict.ContainsKey(type))
        {
            return monsterDict[type];
        }

        return null;
    }
}
