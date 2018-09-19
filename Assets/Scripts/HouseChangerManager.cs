using Engine;

public class HouseChangerManager : Singleton<HouseChangerManager>
{
    public int CoinsCount;
    public int CurrentState = 0;
    public int CurrentLevel;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}