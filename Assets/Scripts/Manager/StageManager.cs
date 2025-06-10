using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private GameManager gameManager;
    private DataManager dataManager;
    private MonsterSpawner monsterSpawner;
    private Player player;

    [SerializeField] private int curStageKey;
    private List<Monster> waveMonsters = new List<Monster>();
    private StageData stageData;
    private MapInfo mapInfo;

    private Coroutine stageCoroutine;

    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
        player = gameManager.Player;
        dataManager = gameManager.DataManager;

        monsterSpawner = GetComponentInChildren<MonsterSpawner>();

        if (monsterSpawner)
            monsterSpawner.Init(dataManager);

        SetStage(1);
    }

    public void SetStage(int stageKey)
    {
        if (stageCoroutine != null)
        {
            StopCoroutine(stageCoroutine);
        }

        curStageKey = stageKey;
        StartStage();
    }

    public void StartStage()
    {
        stageData = dataManager.GetStageDataByStageKey(curStageKey);

        if (stageData != null)
        {
            mapInfo = Instantiate(stageData.stagePrefab).GetComponent<MapInfo>();
            player.StartStage(mapInfo.GetPlayerPosition());

            stageCoroutine = StartCoroutine(StageCoroutine());
        }
    }

    IEnumerator StageCoroutine()
    {
        foreach (var wave in stageData.waves)
        {
            SpawnWave(wave, () =>
            {
                player.SetMonsters(waveMonsters);
            });

            yield return new WaitUntil(() => IsWaveCleared());
            yield return new WaitForSeconds(wave.delayToNextWave);
        }

        if (stageData.hasBoss)
        {
            SpawnBoss(stageData.bossType);
            yield return new WaitUntil(() => IsBossDeath());
        }

        yield return new WaitForSeconds(3f);
        StartStage();
    }

    private void SpawnWave(WaveData wave, Action onCompleted)
    {
        waveMonsters.Clear();

        foreach (var spawn in wave.monsterSpawns)
        {
            for (int i = 0; i < spawn.count; i++)
            {
                Monster monster = monsterSpawner.SpawnMonster(spawn.monsterType, mapInfo.GetRandomSpawnPosition());
                monster.Init(this, player, curStageKey);

                waveMonsters.Add(monster);
            }
        }

        onCompleted?.Invoke();
    }

    private void SpawnBoss(string bossType)
    {
        Monster boss = monsterSpawner.SpawnMonster(bossType, mapInfo.GetRandomSpawnPosition());
    }

    private bool IsWaveCleared()
    {
        return waveMonsters.Count == 0;
    }

    private bool IsBossDeath()
    {
        return false;
    }

    public void RemoveMonster(Monster monster)
    {
        if (waveMonsters.Contains(monster))
            waveMonsters.Remove(monster);
    }
}
