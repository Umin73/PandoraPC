using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SellByDate : MonoBehaviour
{
    private InGameManager GM;
    public Storage storage;

    private DateTime today;
    private DateTime date;

    int randomNum;
    public Text sellbyDate;

    public bool bad;

    public GameObject child;

    private void Start()
    {
        GM = GameObject.Find("InGameManager").GetComponent<InGameManager>();
         Reset();
    }

    private void FixedUpdate()
    {
        if (storage.complete)
        {
            Reset();
        }
    }

    public void Reset()
    {
        sellbyDate = child.GetComponent<Text>();

        this.GetComponent<Button>().interactable = true;
        storage.badCnt = 0;

        randomNum = UnityEngine.Random.Range(-500, 365);
        today = DateTime.Today;
        date = today.AddDays(randomNum);

        sellbyDate.text = date.ToString("yy/MM/dd");

        if (DateTime.Compare(today, date) < 0) //������� ����������
        {
            bad = false;

        }
        else
        {
            bad = true; //������� �����ų� ���ñ�����
            storage.badMax++;
        }
    }

    /*public void SetDate()
    {
        do
        {
            storage.badMax = 0;

            randomNum = UnityEngine.Random.Range(-500, 365);
            today = DateTime.Today;
            date = today.AddDays(randomNum);

            sellbyDate.text = date.ToString("yy/MM/dd");

            if (DateTime.Compare(today, date) < 0) //������� ����������
            {
                bad = false;

            }
            else
            {
                bad = true; //������� �����ų� ���ñ�����
                storage.badMax++;
            }

        } while (storage.badMax != 0 || storage.badMax != 9);
    }*/


    public void OnClick()
    {
        if(bad == false)
        {
            storage.warning.SetActive(true);
            StartCoroutine("WarningExitDelay");
        }
        else
        {
            storage.badCnt++;
            this.GetComponent<Button>().interactable = false;
            if (storage.badCnt == storage.badMax)
            {
                storage.clear.SetActive(true);
                StartCoroutine("ClearExitDelay");
            }
        }
    }


    IEnumerator WarningExitDelay()
    {
        yield return new WaitForSeconds(1f);
        storage.warning.SetActive(false);
    }

    IEnumerator ClearExitDelay()
    {
        GM.StorageClear();
        yield return new WaitForSeconds(1f);
        storage.badMax = 0;
        storage.complete = true;
        storage.clear.SetActive(false);
        storage.panel.SetActive(false);
    }
}