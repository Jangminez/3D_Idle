using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : UnitBase
{
    [SerializeField] private MonsterStatSO monsterStatSO;
    [SerializeField] private int currentStage = 1;

    private int dropGold;
    private int dropExp;

    Player player;

    protected override void Start()
    {
        statSO = monsterStatSO;
        unitStat = monsterStatSO.GetStatByLevel(currentStage);

        dropGold = monsterStatSO.GetGoldDrop(currentStage);
        dropExp = monsterStatSO.GetExpDrop(currentStage);

        base.Start();
    }

    
}
