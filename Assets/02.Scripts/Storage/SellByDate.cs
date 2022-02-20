using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SellByDate : MonoBehaviour
{
    public Storage storage;

    private DateTime today;
    private DateTime date;

    int randomNum;
    public Text sellbyDate;

    public bool bad;

    public GameObject child;

    private void Start()
    {
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

        if (DateTime.Compare(today, date) < 0) //유통기한 안지났으면
        {
            bad = false;

        }
        else
        {
            bad = true; //유통기한 지났거나 오늘까지면
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

            if (DateTime.Compare(today, date) < 0) //유통기한 안지났으면
            {
                bad = false;

            }
            else
            {
                bad = true; //유통기한 지났거나 오늘까지면
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
        yield return new WaitForSeconds(2f);
        storage.warning.SetActive(false);
    }

    IEnumerator ClearExitDelay()
    {
        yield return new WaitForSeconds(2f);
        storage.badMax = 0;
        storage.complete = true;
        storage.clear.SetActive(false);
        storage.panel.SetActive(false);
    }
}