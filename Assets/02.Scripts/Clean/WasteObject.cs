using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WasteObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler
{
    private WasteBin wasteBin;
    private WasteManager wasteManager;

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
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
    public void OnDrop(PointerEventData eventData)
    {
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        transform.position = originPos;
    }

    public void ResetObject()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        transform.position = originPos;
        oneself.SetActive(true);
    }

}
