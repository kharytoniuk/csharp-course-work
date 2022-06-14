﻿using System;

namespace ExplorerDesktop;

public class NavigationStore
{
    private BaseViewModel _currentViewModel;
    public event Action? Changed;

    public BaseViewModel CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            Changed?.Invoke();
        }
    }
}