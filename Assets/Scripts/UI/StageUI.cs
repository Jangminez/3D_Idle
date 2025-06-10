using System.Collections.Generic;
using UnityEngine;

public class StageUI : MonoBehaviour
{
    private StageManager stageManager;
    private DataManager dataManager;

    [SerializeField] GameObject stageSlotPrefab;
    [SerializeField] Transform stageContent;

    public void Init(StageManager stageManager, DataManager dataManager)
    {
        this.stageManager = stageManager;
        this.dataManager = dataManager;

        SetStage();
    }

    private void SetStage()
    {
        Dictionary<int, StageData> stageDict = dataManager.GetStageDict();

        foreach (var key in stageDict.Keys)
        {
            if (Instantiate(stageSlotPrefab, stageContent).TryGetComponent(out StageSlot stageSlot))
            {
                stageSlot.Init(this, stageDict[key]);
            }
        }
    }

    public void StartStage(StageData stageData)
    {
        stageManager.SetStage(stageData.stageKey);
    }
}
