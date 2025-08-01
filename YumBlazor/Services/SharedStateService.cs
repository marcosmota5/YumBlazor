﻿namespace YumBlazor.Services;

public class SharedStateService
{
    public event Action OnChange;
    private int _totalCartCount;

    public int TotalCartCount
    {
        get => _totalCartCount;
        set
        {
            if (_totalCartCount != value)
            {
                _totalCartCount = value;
                NotifyStateChanged();
            }
        }
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
