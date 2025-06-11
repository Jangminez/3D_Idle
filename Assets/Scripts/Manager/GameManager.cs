using System;
using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player Player { get; private set; }
    public StageManager StageManager { get; private set; }
    public DataManager DataManager { get; private set; }
    public UIManager UIManager { get; private set; }

    public int CurStageKey { get; private set; } = 1;
    public event Action<int> onStageChanged;

    protected override void Awake()
    {
        base.Awake();

        DataManager = GetComponentInChildren<DataManager>();

        Player = FindObjectOfType<Player>();
        StageManager = GetComponentInChildren<StageManager>();
        UIManager = GetComponentInChildren<UIManager>();
    }

    void Start()
    {
        if (StageManager)
            StageManager.Init(this);

        if (UIManager)
            UIManager.Init(this);

        Player.Init(1);

        ChangeStage(CurStageKey);
    }

    public void ChangeStage(int stageKey)
    {
        CurStageKey = stageKey;
        StageManager.SetStage(CurStageKey);

        onStageChanged?.Invoke(CurStageKey);
    }

    public void RestartStage()
    {
        StageManager.SetStage(CurStageKey);
    }
}
