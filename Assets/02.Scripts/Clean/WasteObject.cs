using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WasteObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler
{
    private WasteBin wasteBin;

    [HideInInspector]public Vector3 originPos;
    private CanvasGroup canvasGroup;
    public GameObject oneself;


    public void Start()
    {
        originPos = transform.position;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
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
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        transform.position = originPos;
        Debug.Log("End Drag");
    }

}
