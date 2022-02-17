using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDropHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public FoodProperty food;
    [HideInInspector] public Cook cook;
    [HideInInspector] public Vector3 originPos;

    private Inventory inventory;
    private InventoryTrash trash;
    private CanvasGroup canvasGroup;

    public Image image;
    public GameObject oneself;

    public void Start()
    {
        oneself = this.gameObject;
        originPos = transform.position;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(this.food != null)
        {
            transform.position = eventData.position;
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
            Debug.Log("Begin Drag");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(this.food != null)
        {
            transform.position = eventData.position;
            Debug.Log("Drag");
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(this.food != null)
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
            transform.position = originPos;
            Debug.Log("End Drag");
        }
    }

    public void SetFood(FoodProperty _food)
    {
        this.food = _food;

        if (_food == null)
        {
            image.enabled = false;
            gameObject.name = "Empty";
        }
        else
        {
            image.enabled = true;
            gameObject.name = food.foodName;
            image.sprite = food.foodSprite;
            oneself = this.gameObject;
        }
    }

    public void ResetFood()
    {
        //inventory.curSlot--;
        image.enabled = false;
        gameObject.name = "Empty";
    }
}
