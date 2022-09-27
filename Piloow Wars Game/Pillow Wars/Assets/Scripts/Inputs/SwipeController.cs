#region External
using DigitalRubyShared;
#endregion
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    private SwipeGestureRecognizer swipeGesture;
    public static event System.Action<SwipeGestureRecognizerDirection> OnSwipeEnded;

    void Start()
    {
        CreateSwipeGesture();
    }
    private void CreateSwipeGesture()
    {
        swipeGesture = new SwipeGestureRecognizer();
        swipeGesture.Direction = SwipeGestureRecognizerDirection.Any;
        swipeGesture.StateUpdated += SwipeGestureCallback;
        swipeGesture.DirectionThreshold = 1.0f; // allow a swipe, regardless of slope
        FingersScript.Instance.AddGesture(swipeGesture);
    }
    private void SwipeGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Ended)
            OnSwipeEnded?.Invoke(swipeGesture.EndDirection);
    }
}