using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElecManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject clear;
    private InGameManager GM;

    public bool elecGoOut; //���� �������� ���� 

    public GameObject[] ButtonList;
    private int listSize;
    private int randomNum;

    private int cur;

    private void Start()
    {
        ButtonList = GameObject.FindGameObjectsWithTag("elecButton");
        GM = GameObject.Find("InGameManager").GetComponent<InGameManager>();

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
        cur = 0;
        for(cur = 0; cur < listSize; cur++)
        {
            if (ButtonList[cur].GetComponent<ElecButton>().isDown == true) break;
        }

        if (cur == listSize)
        {
            clear.SetActive(true);
            StartCoroutine("DelayExit");
            
        }

    }

    public void ResetElec()
    {
        randomNum = UnityEngine.Random.Range(0, listSize);
        Debug.Log(randomNum);

        for (int i = 0; i < listSize; i++)
        {
            if (i == randomNum) ButtonList[i].GetComponent<ElecButton>().DOWN();
            else ButtonList[i].GetComponent<ElecButton>().UP();
        }

        cur = 0;
    }

    IEnumerator DelayExit()
    {
        GM.ElecClear();
        yield return new WaitForSeconds(1f);
        ResetElec();
        clear.SetActive(false);
        panel.SetActive(false);
    }
}
