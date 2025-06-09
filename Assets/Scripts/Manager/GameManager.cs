public class GameManager : Singleton<GameManager>
{
    Player player;
    StageManager stageManager;
    DataManager dataManager;

    protected override void Awake()
    {
        base.Awake();

        player = FindObjectOfType<Player>();
        stageManager = GetComponentInChildren<StageManager>();
        dataManager = GetComponentInChildren<DataManager>();

        if (stageManager)
            stageManager.Init(this, dataManager, player);
    }

    void Start()
    {
        player.Init(1);
    }
}
