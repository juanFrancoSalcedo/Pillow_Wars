using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentClick : MonoBehaviour
{
    [SerializeField] Canvas canvas = null;
    private DragController dragController = null;
    Camera cam = null;
    private void Start()
    {
        cam = Camera.main;
        dragController = DragController.Instance;
        dragController.OnDragged += SetPosition;
    }

    private void OnDestroy()
    {
        dragController.OnDragged -= SetPosition;
    }

    private void SetPosition(Vector3 pos)
    {
        Vector2 posisitionRect;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform, Input.mousePosition,
            canvas.worldCamera,
            out posisitionRect);


        var rectTrans = (RectTransform)transform;
        rectTrans.anchoredPosition = posisitionRect;
    }
}
