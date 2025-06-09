public class GameManager : Singleton<GameManager>
{
    Player player;
    StageManager stageManager;
    DataManager dataManager;
    UIManager uIManager;

    protected override void Awake()
    {
        base.Awake();

        player = FindObjectOfType<Player>();
        stageManager = GetComponentInChildren<StageManager>();
        dataManager = GetComponentInChildren<DataManager>();
        uIManager = GetComponentInChildren<UIManager>();
    }

    void Start()
    {
        if (stageManager)
            stageManager.Init(this, dataManager, player);

        if (uIManager)
            uIManager.Init(this, player.Events);
            
        player.Init(1);
    }
}
