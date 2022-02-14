using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform rootSlot;
    public Cook cook;

    private List<InventorySlot> slots;

    private int slotCnt;
    public int curSlot;
    public bool input;

    void Start()
    {
        slots = new List<InventorySlot>();

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
        if (curSlot <= 4) input = true;
        else input = false;
    }

    void Cooked(FoodProperty food)
    {
        Debug.Log(food.foodName);
        var emptySlot = slots.Find(f => f.food == null || f.food.foodName == string.Empty); //슬롯 순회하면서 비어있는 곳 찾기

        if (emptySlot != null)
        {
            Debug.Log("슬롯에 넣기!");
            emptySlot.SetFood(food); //텅빈 슬롯 있으면 음식 넣기
            curSlot++;
        }
        else
        {
            Debug.Log("슬롯이 꽉찼음");
            //꽉찼다는 메세지창 띄우기
        }
    }
}
