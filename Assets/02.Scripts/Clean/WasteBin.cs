using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WasteBin : MonoBehaviour, IDropHandler
{
    [HideInInspector] public Vector3 curPos;

    //private WasteManager wasteManager;


    public void OnDrop(PointerEventData eventData)
    {
        if(this.name == "WasteBin_Paper")
        {
            if(eventData.pointerDrag.GetComponent<WasteObject>().oneself.tag == "trash_paperCup")
            {
                eventData.pointerDrag.GetComponent<WasteObject>().oneself.SetActive(false);
                //Destroy(eventData.pointerDrag.GetComponent<WasteObject>().oneself);
            }
        }
        else
        {
            if(eventData.pointerDrag.GetComponent<WasteObject>().oneself.tag == "trash_can")
            {
                eventData.pointerDrag.GetComponent<WasteObject>().oneself.SetActive(false);
                //Destroy(eventData.pointerDrag.GetComponent<WasteObject>().oneself);
            }
        }
        Debug.Log("WasteBin");
    }

}
