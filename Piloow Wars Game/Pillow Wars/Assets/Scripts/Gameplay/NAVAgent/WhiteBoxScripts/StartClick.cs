using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartClick : MonoBehaviour
{
    [SerializeField] Canvas canvas = null;
    private DragController dragController = null;
    Camera cam = null;
    private void Start()
    {
        cam = Camera.main;
        dragController = DragController.Instance;
        dragController.OnDragBegan += SetPosition;
    }

    private void OnDestroy()
    {
        dragController.OnDragBegan -= SetPosition;
    }

    private void SetPosition(Vector3 pos) 
    {

        Vector2 posisitionRect;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform, pos,
            canvas.worldCamera,
            out posisitionRect);

        var ndb = cam.ScreenToWorldPoint(pos);

        var rectTrans = (RectTransform)transform;
        rectTrans.anchoredPosition = posisitionRect;
    }
}
