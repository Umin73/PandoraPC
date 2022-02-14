using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSite : MonoBehaviour
{
    public GameObject warning; //오류 창
    public GameObject clear; //클리어 창
    public GameObject orderSite;
    public GameObject exitButton;
    public GameObject counterPanel;

    public int finish;
    private int finishMax;


    void Start()
    {
        finishMax = 3;
        finish = 0;
    }

    private void Update()
    {
        if (finish == finishMax)
        {
            clear.SetActive(true);
            StartCoroutine("ExitOrder");
        }
    }

    public void Enter()
    {
        orderSite.SetActive(true);
    }

    public void Exit()
    {
        orderSite.SetActive(false);
    }

    IEnumerator ExitOrder()
    {
        yield return new WaitForSeconds(2f);
        clear.SetActive(false);
        counterPanel.SetActive(false);
    }
}
