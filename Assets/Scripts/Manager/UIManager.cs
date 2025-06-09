using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
    public PlayerEventHandler PlayerEvents { get; private set; }
    private GameUI gameUI;

    public void Init(GameManager gameManager, PlayerEventHandler playerEvent)
    {
        this.gameManager = gameManager;
        PlayerEvents = playerEvent;

        gameUI = GetComponentInChildren<GameUI>();

        if (gameUI)
            gameUI.Init(this);
    }
}
