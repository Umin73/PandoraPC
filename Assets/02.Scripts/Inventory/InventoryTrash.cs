using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryTrash : MonoBehaviour, IDropHandler
{
    [HideInInspector] public Vector3 curPos;
    private Inventory inventory;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag.GetComponent<InventorySlot>().oneself.tag == "FoodItem")
        {
            eventData.pointerDrag.GetComponent<InventorySlot>().ResetFood();
        }
    }
}
