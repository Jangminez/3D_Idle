using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveData
{
    public List<WaveSpawnInfo> monsterSpawns;
    public float delayToNextWave;
}

[System.Serializable]
public class WaveSpawnInfo
{
    public string monsterType;
    public int count;
}

[CreateAssetMenu(fileName = "StageData", menuName = "StageData/New StageData")]
public class StageData : ScriptableObject
{
    public int stageKey;
    public GameObject stagePrefab;
    public List<WaveData> waves;
    public bool hasBoss;
    public string bossType;
}
