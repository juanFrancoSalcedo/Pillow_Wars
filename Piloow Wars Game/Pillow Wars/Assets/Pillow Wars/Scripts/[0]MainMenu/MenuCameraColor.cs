using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuCameraColor : MonoBehaviour
{
    [SerializeField] private Image image = null;
    [SerializeField] private MainMenuAnimationController menuAnimationController = null;

    private void OnEnable()
    {
        SwipePivotRotation.OnRotated += ChangeColor;
    }

    private void OnDisable()
    {
        SwipePivotRotation.OnRotated -= ChangeColor;
    }


    private void ChangeColor() 
    {
        var r = SwipePivotRotation.buttonDisplayed;
        image.DOColor(menuAnimationController.AnimationsStatement.Find(e => e.nameObject.Equals(r.name)).color,2);
    }
}
