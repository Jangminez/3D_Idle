using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
    public Player Player { get; private set; }
    private GameUI gameUI;
    private InventoryUI inventoryUI;

    [Header("Tab Buttons")]
    [SerializeField] Button inventoryButton;
    [SerializeField] Button stageButton;
    [SerializeField] Button shopButton;
    [SerializeField] Button statusButton;

    List<GameObject> togglePanels = new List<GameObject>();

    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
        Player = gameManager.Player;

        gameUI = GetComponentInChildren<GameUI>();
        inventoryUI = GetComponentInChildren<InventoryUI>();

        if (gameUI)
            gameUI.Init(this);

        if (inventoryUI)
            inventoryUI.Init(this);

        togglePanels.Add(inventoryUI.gameObject);

        inventoryButton.onClick.AddListener(() => TogglePanel(inventoryUI.gameObject));

        InitPanel();
    }

    private void InitPanel()
    {
        foreach (var panel in togglePanels)
        {
            panel.SetActive(false);
        }
    }

    private void TogglePanel(GameObject panel)
    {
        bool isActive = panel.activeSelf;

        foreach (var p in togglePanels)
        {
            p.SetActive(false);
        }

        panel.SetActive(!isActive);
    }
}
