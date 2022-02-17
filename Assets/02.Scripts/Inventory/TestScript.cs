using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler
{
    [HideInInspector] public Vector3 originPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        Debug.Log("Begin Drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        Debug.Log("Drag");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
    }
}
