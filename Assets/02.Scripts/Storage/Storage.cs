using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private SellByDate sellByDate;

    public Transform boxRoot;
    public List<SellByDate> sellByDates;

    public GameObject panel;
    public GameObject warning;
    public GameObject clear;

    public int badCnt = 0;
    public int badMax = 0;

    public bool complete;

    private void Start()
    {
        sellByDates = new List<SellByDate>();
    }

    private void Update()
    {
        if (this.gameObject.activeSelf == true) complete = false;
        else complete = true;
    }
}
