using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSite : MonoBehaviour
{
    private Order order;

    public GameObject warning; //오류 창
    public GameObject clear; //클리어 창
    public GameObject orderSite;
    public GameObject exitButton;
    public GameObject counterPanel;

    public int finish;
    private int finishMax;
    public Transform[] orderRoot;

    [HideInInspector]public bool complete;


    void Start()
    {
        finishMax = 3;
        finish = 0;
        complete = false;
    }

    private void Update()
    {
        if (finish == finishMax)
        {
            clear.SetActive(true);
            StartCoroutine("ExitOrder");
        }
    }

    void ResetOrder()
    {
        finish = 0;
        for (int k = 0; k < orderRoot.Length; k++)
        {
            var orderObject = orderRoot[k].GetComponent<Order>();
            orderObject.ResetQuantity();
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
        yield return new WaitForSeconds(1f);
        ResetOrder();
        clear.SetActive(false);
        counterPanel.SetActive(false);
    }
}
