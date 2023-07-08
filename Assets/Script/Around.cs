using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Around : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private bool isDrag = false;


    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDrag)
        {
            var delta = eventData.delta;
            transform.Rotate(Vector3.forward, -delta.x);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
    }
}
