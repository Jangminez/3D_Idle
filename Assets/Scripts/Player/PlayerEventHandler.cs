using System;

public class PlayerEventHandler
{
    public event Action<int, int> onRewarded;
    public event Action<int> onLevelChanged;

    public void RaiseRewarded(int gold, int exp) => onRewarded?.Invoke(gold, exp);
    public void RaiseLevelChanged(int level) => onLevelChanged?.Invoke(level);
}
