using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public OrderSite orderSite;

    [SerializeField] private Text orderName; //주문할 것의 이름
    [SerializeField] private Text Quantity; //수량 표시
    [SerializeField] private InputField orderQuantity; //입력 수량
    [SerializeField] public Button orderButton; //주문 버튼

    private int curQuantity; //현재 수량
    private int maxQuantity; //최대 수량


    void Start()
    {
        setQuantity();
    }

    /*private void Update()
    {
        if (orderSite.complete)
        {
            orderSite.clear.SetActive(true);
            StartCoroutine("ExitOrder");
        }
    }*/

    public void setQuantity()
    {
        curQuantity = Random.Range(10, 90);
        maxQuantity = 100;

        Quantity.text = curQuantity.ToString() + "/" + maxQuantity.ToString();
    }

    public void Input()
    {
        int temp = curQuantity + int.Parse(orderQuantity.text);
        if ( temp == maxQuantity)
        {
            curQuantity += int.Parse(orderQuantity.text); //현재 수량에 입력 수량만큼 더함
            Quantity.text = curQuantity.ToString() + "/" + maxQuantity.ToString();
            orderSite.finish++;
            orderButton.interactable = false; //주문 더이상 못하게 버튼 비활성화
        }
        else if( temp < maxQuantity)
        {
            curQuantity += int.Parse(orderQuantity.text); //현재 수량에 입력 수량만큼 더함
            Quantity.text = curQuantity.ToString() + "/" + maxQuantity.ToString();
        }
        else if ( temp > maxQuantity)
        {
            orderSite.warning.SetActive(true);
            StartCoroutine("WarningExitDelay");
        }
    }

    public void ResetQuantity()
    {
        setQuantity();
        orderQuantity.text = "";
        orderButton.interactable = true;
    }

    IEnumerator WarningExitDelay()
    {
        yield return new WaitForSeconds(2f);
        orderSite.warning.SetActive(false);
    }

    /*IEnumerator ExitOrder()
    {
        yield return new WaitForSeconds(2f);
        orderSite.ResetOrder();
        orderSite.clear.SetActive(false);
        orderSite.counterPanel.SetActive(false);
    }*/

}
