using UnityEngine;

public class Monster : UnitBase
{
    private StageManager stageManager;

    [SerializeField] private MonsterStatSO monsterStatSO;
    [SerializeField] private int currentStage = 1;

    private int dropGold;
    private int dropExp;

    Player player;

    public override void Init(StageManager stageManager, Player player, int stage)
    {
        this.stageManager = stageManager;
        Target = player.transform;
        
        currentStage = stage;

        statSO = monsterStatSO;
        unitStat = monsterStatSO.GetStatByLevel(currentStage);

        dropGold = monsterStatSO.GetGoldDrop(currentStage);
        dropExp = monsterStatSO.GetExpDrop(currentStage);

        base.Init(stage);
    }

    public void SetStageManager(StageManager stageManager)
    {
        this.stageManager = stageManager;
    }

    protected override void Die()
    {
        stageManager.RemoveMonster(this);

        base.Die();
    }
}
