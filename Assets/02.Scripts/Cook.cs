using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cook : MonoBehaviour
{
    public FoodDB foodDB;
    public Transform slotRoot;
    private List<Slot> slots;

    public bool use = false;

    public System.Action<FoodProperty> doneCook;

    private void Start()
    {
        slots = new List<Slot>();

        int slotCnt = slotRoot.childCount;

        for(int i = 0; i < slotCnt; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();

            if (i < foodDB.foods.Count)
            {
                slot.SetFood(foodDB.foods[i]);
            }
            else
            {
                slot.GetComponent<Button>().interactable = false; //조리 못하게 버튼 비활성화
            }

            slots.Add(slot);
        }
    }

    public void DoneCook(Slot slot)
    {
        if (slot.finish)
        {
            if (doneCook != null)
            {
                doneCook(slot.food);
                Debug.Log("DoneCook");
            }
        }
        slot.finish = false;
    }

}
