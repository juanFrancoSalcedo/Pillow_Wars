using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationAgentPositioner 
{
    public IAgentPositionModifiable navTarget = null;

    public NavigationAgentPositioner() => navTarget = new NavigationTarget();
    public void SetPosition(Vector3 position) => navTarget.Position = position;
}
