using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
    public Player Player { get; private set; }
    public GameUI GameUI { get; private set; }
    public InventoryUI InventoryUI { get; private set; }
    public ShopUI ShopUI { get; private set; }


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

        GameUI = GetComponentInChildren<GameUI>();
        InventoryUI = GetComponentInChildren<InventoryUI>();
        ShopUI = GetComponentInChildren<ShopUI>();

        if (GameUI)
            GameUI.Init(this);

        if (InventoryUI)
            InventoryUI.Init(Player);

        if (ShopUI)
            ShopUI.Init(this, gameManager.DataManager);

        togglePanels.Add(InventoryUI.gameObject);
        togglePanels.Add(ShopUI.gameObject);

        inventoryButton.onClick.AddListener(() => TogglePanel(InventoryUI.gameObject));
        shopButton.onClick.AddListener(() => TogglePanel(ShopUI.gameObject));

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
