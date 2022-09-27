using DigitalRubyShared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BadWaters;

public class DragController : Singleton<DragController>
{
    //public float SwipeMagnitudeMove = 10;
    [Tooltip("Pass Must be higher than Swipe Move")]
    public float SwipeMagnitudePass = 20;
    public event System.Action<Vector3> OnDragBegan;
    public event System.Action<Vector3> OnDragged;
    public event System.Action<Vector3> OnDragedEnd;

    private Vector3[] previousPointerPos;

    Vector3 startPosition;
    Vector3 currentPosition;
    int indexPos;

    private new void Awake()
    {
        base.Awake();
        previousPointerPos = new Vector3[7];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            OnDragBegan?.Invoke(startPosition);
        }


        if (Input.GetMouseButton(0))
        {
            currentPosition = Input.mousePosition;
            OnDragged?.Invoke(currentPosition - startPosition);
        }

        previousPointerPos[indexPos] = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
            OnDragedEnd?.Invoke(GetDraggEnd());

        indexPos++;
        if (indexPos > 6)
            indexPos = 0;
    }

    public Vector3 GetDraggEnd()
    {
        Vector3 force = Input.mousePosition - previousPointerPos[indexPos];
        if (force.magnitude > SwipeMagnitudePass)
            return force;
        else
            return Vector3.zero;
    }
}
