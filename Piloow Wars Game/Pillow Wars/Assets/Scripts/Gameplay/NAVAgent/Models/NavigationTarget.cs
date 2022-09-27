using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationTarget : IAgentPositionModifiable
{
    public event IAgentPositionModifiable.PositionEvent OnPositionChanged;

    private Vector3 position;
    public Vector3 Position 
    {
        get => position;
        set 
        {
            if (position != value)
            {
                position = value;
                OnPositionChanged?.Invoke(position);
            }
        }
    }
}