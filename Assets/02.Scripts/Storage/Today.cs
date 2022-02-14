using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Today : MonoBehaviour
{

    private DateTime today;
    public Text todayText;

    void Start()
    {
        today = DateTime.Today;
        todayText.text = today.ToString("yy/MM/dd");
    }

}
