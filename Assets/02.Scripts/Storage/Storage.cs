using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public Transform boxRoot;
    private List<SellByDate> sellByDates;

    public GameObject panel;
    public GameObject warning;
    public GameObject clear;

    public int badCnt = 0;
    public int badMax = 0;

    void Start()
    {
        sellByDates = new List<SellByDate>();

        for(int i = 0; i < sellByDates.Count; i++)
        {
            var box = boxRoot.GetChild(i).GetComponent<SellByDate>();
            if (box.bad == true) badMax++;
        }
    }

}
