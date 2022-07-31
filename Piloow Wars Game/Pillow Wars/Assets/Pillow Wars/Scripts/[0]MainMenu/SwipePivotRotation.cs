#region External
using DigitalRubyShared;
#endregion
using UnityEngine;
using DG.Tweening;
using System;
using System.Collections.Generic;
using Newronizer;

public class SwipePivotRotation : Singleton<SwipePivotRotation>
{
    public static event Action OnRotated;
    [Header("~~~~Animations Elements~~~~")]
    [SerializeField] private RectTransform centerCircle;
    [SerializeField] private List<MenuBtnAnimationListener> circleElements = new List<MenuBtnAnimationListener>();
    private MenuBtnAnimationListener lastSelected = null;
    public static RectTransform buttonDisplayed = null;

    private void Start()
    {
        lastSelected = circleElements[0];
        PlayAnimation(SwipeGestureRecognizerDirection.Up);
    }

    private void OnEnable()
    {
        SwipeController.OnSwipeEnded += PlayAnimation;
    }

    private void OnDisable()
    {
        SwipeController.OnSwipeEnded -= PlayAnimation;
    }

    private float Angle => (float)360 / circleElements.Count;

    private void PlayAnimation(SwipeGestureRecognizerDirection direction) 
    {
        if (direction == SwipeGestureRecognizerDirection.Up)
            SelectAnimationState('+');
        else if (direction == SwipeGestureRecognizerDirection.Down)
            SelectAnimationState('-');
    }

    private void SelectAnimationState(char plusLess)
    {
        int index = circleElements.IndexOf(lastSelected);
        index = Constraints(plusLess, index);
        lastSelected = circleElements[index];
        Vector3 rotation = centerCircle.localRotation.eulerAngles;
        rotation.z = Angle * (index);
        centerCircle.DORotate(rotation, 0.5f, RotateMode.FastBeyond360).SetEase(Ease.InExpo).OnComplete(InvokeEvent);
    }

    private int Constraints(char plusLess, int index)
    {
        if (plusLess.Equals('+'))
        {
            index++;
            if (index >= circleElements.Count)
                index = 0;
        }
        else
        {
            index--;
            if (index < 0)
                index = circleElements.Count - 1;
        }
        return index;
    }

    private void InvokeEvent()
    {
        buttonDisplayed = GetDisplayedTransform();
        OnRotated?.Invoke();
    }

    private RectTransform GetDisplayedTransform() 
    {
        var tra = (RectTransform)circleElements[0].transform;
        for (int i = 0; i < circleElements.Count; i++)
        {
            var t = (RectTransform)circleElements[i].transform;
            if (t.position.x > 2)
                tra = t;
        }
        return tra;
    }
}

