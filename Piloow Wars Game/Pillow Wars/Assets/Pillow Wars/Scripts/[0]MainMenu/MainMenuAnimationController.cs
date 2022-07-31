using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private List<MainMenuKeyAnimation> animationsStatement = new List<MainMenuKeyAnimation>();

    private void OnEnable()
    {
        SwipePivotRotation.OnRotated += ActiveAnimation;
    }

    private void OnDisable()
    {
        SwipePivotRotation.OnRotated -= ActiveAnimation;
    }

    private string nameBuffer ="";

    void ActiveAnimation()
    {
        var other = SwipePivotRotation.buttonDisplayed;
        if (!animationsStatement.Exists(a => a.nameObject.Equals(other.name)))
            return;
        string nameAnimation = "";
        nameAnimation = animationsStatement.Find(a => a.nameObject.Equals(other.name)).sufix;
        animator.SetBool(nameAnimation,true);
        if (!string.IsNullOrEmpty(nameBuffer))
            animator.SetBool(nameBuffer,false);
        
        nameBuffer = nameAnimation;
    }

    public List<MainMenuKeyAnimation> AnimationsStatement => animationsStatement;

    [System.Serializable]
    public struct MainMenuKeyAnimation
    {
        [Tooltip("Its need equals with the name of the object, in this case the button that was displayed in the middle of the screen")]
        public string nameObject;
        [Tooltip("name of animation trigger")]
        public string sufix;
        public Color color;
    }
}
