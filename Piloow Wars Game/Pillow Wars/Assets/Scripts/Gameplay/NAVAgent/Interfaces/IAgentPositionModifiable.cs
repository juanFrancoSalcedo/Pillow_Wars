using UnityEngine;

public interface IAgentPositionModifiable 
{
    public delegate void PositionEvent(Vector3 position);
    public event PositionEvent OnPositionChanged;
    public Vector3 Position { get; set; }
}
