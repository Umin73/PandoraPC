using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElecManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject clear;

    public bool elecGoOut; //전기 꺼졌는지 여부 
                           //인게임 매니저에서 플레이 시간동안 2?번 정도 랜덤으로 전기 나가게 만들기

    public GameObject[] ButtonList;
    private int listSize;
    private int randomNum;

    private void Start()
    {
        ButtonList = GameObject.FindGameObjectsWithTag("elecButton");

        elecGoOut = false;
        listSize = 5;

        randomNum = UnityEngine.Random.Range(0, listSize);
        Debug.Log(randomNum);

        for(int i = 0; i < listSize; i++)
        {
            if (i == randomNum) ButtonList[i].GetComponent<ElecButton>().DOWN();
            else ButtonList[i].GetComponent<ElecButton>().UP();
        }
    }

    private void Update()
    {
        int i = 0;
        for(i = 0; i < listSize; i++)
        {
            if (ButtonList[i].GetComponent<ElecButton>().isDown == true) break;
        }

        if (i == listSize)
        {
            clear.SetActive(true);
            StartCoroutine("DelayExit");
        }

    }


    IEnumerator DelayExit()
    {
        yield return new WaitForSeconds(2f);
        clear.SetActive(false);
        panel.SetActive(false);
    }
}
