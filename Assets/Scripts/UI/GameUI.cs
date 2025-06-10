using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private UIManager uIManager;
    private PlayerEventHandler playerEvent;
    [SerializeField] Image expBar;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI goldText;

    public void Init(UIManager uIManager)
    {
        this.uIManager = uIManager;
        playerEvent = uIManager.Player.Events;

        OnEnable();
    }

    void OnEnable()
    {
        if (playerEvent == null) return;

        playerEvent.onLevelChanged += UpdateLevelUI;
        playerEvent.onExpChanged += UpdateExpUI;
        playerEvent.onGoldChanged += UpdateGoldUI;
    }
    
    void OnDisable()
    {
        playerEvent.onLevelChanged -= UpdateLevelUI;
        playerEvent.onExpChanged -= UpdateExpUI;
        playerEvent.onGoldChanged -= UpdateGoldUI;
    }

    private void UpdateLevelUI(int level)
    {
        levelText.text = $"Lv.{level}";
    }

    private void UpdateExpUI(int currentExp, int requiredExp)
    {
        expBar.fillAmount = (float)currentExp / (float)requiredExp;
    }

    private void UpdateGoldUI(int gold)
    {
        goldText.text = gold.ToString();
    }
}
