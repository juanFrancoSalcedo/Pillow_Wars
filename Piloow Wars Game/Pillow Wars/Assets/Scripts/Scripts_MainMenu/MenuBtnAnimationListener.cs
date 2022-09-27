#region External
#endregion
using UnityEngine;

public class MenuBtnAnimationListener : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

    private void OnEnable()
    {
        SwipePivotRotation.OnRotated += Equals;
    }

    private void OnDisable()
    {
        SwipePivotRotation.OnRotated -= Equals;
    }

    private void Equals()
    {
        RectTransform rTransform = (RectTransform)transform;
        animator.SetBool("Deploy", name.Equals(SwipePivotRotation.buttonDisplayed.name));
    }
}
