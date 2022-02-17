using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform rootSlot;
    public Cook cook;

    [HideInInspector]public List<InventorySlot> slots;

    private int slotCnt;
    public int curSlot;
    public bool input;

    private GameObject tempObject;

    void Start()
    {
        slots = new List<InventorySlot>();

        curSlot = 0;

        slotCnt = rootSlot.childCount;
        for(int i = 0; i < slotCnt; i++)
        {
            var slot = rootSlot.GetChild(i).GetComponent<InventorySlot>();

            slots.Add(slot);
        }
        cook.doneCook += Cooked;
    }

    private void Update()
    {
        for(curSlot = 0; curSlot < slotCnt; curSlot++)
        {
            if (slots[curSlot].gameObject.name == "Empty")
            {
                input = true; //슬롯 중에서 하나라도 빈 슬롯이 있으면 넣기 가능
                break;
            }
        }
        if (curSlot == slotCnt - 1) input = false;
    }

    void Cooked(FoodProperty food)
    {
        Debug.Log(food.foodName);

        //var emptySlot = slots.Find(f => f.food.foodName == string.Empty); //슬롯 순회하면서 비어있는 곳 찾기

        for(int i = 0; i <= curSlot; i++)
        {
            if(slots[i].gameObject.name == "Empty")
            {
                Debug.Log("슬롯에 넣기!");
                slots[i].GetComponent<InventorySlot>().SetFood(food);
                //curSlot++;
                return;
            }
        }

        /*if (emptySlot != null)
        {
            Debug.Log("슬롯에 넣기!");
            emptySlot.SetFood(food); //텅빈 슬롯 있으면 음식 넣기
            curSlot++;
        }*/

        /*Debug.Log("슬롯에 넣기!");
        emptySlot.SetFood(food); //텅빈 슬롯 있으면 음식 넣기
        curSlot++;*/
    }

}
