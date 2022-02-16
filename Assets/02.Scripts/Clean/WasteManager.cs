using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WasteManager : MonoBehaviour
{
    private WasteBin wasteBin;

    public GameObject panel;
    public GameObject can;
    public GameObject paperCup;
    public GameObject clear;

    public GameObject[] boolCan;
    public GameObject[] boolPaper;

    private int boolCanSize;
    private int boolPaperSize;

    private void Start()
    {
        boolCan = GameObject.FindGameObjectsWithTag("trash_can");
        boolPaper = GameObject.FindGameObjectsWithTag("trash_paperCup");

        boolCanSize = boolCan.Length;
        boolPaperSize = boolPaper.Length;

        clear.SetActive(false);
    }

    private void Update()
    {
        int i, j;
        for(i = 0; i < boolCanSize;i++)
        {
            if (boolCan[i].activeSelf == true) break;
        }
        

        for (j = 0; j < boolPaperSize; j++)
        {
            if (boolPaper[j].activeSelf == true) break;
        }

        if (i == boolCanSize && j == boolPaperSize)
        {
            clear.SetActive(true);
            StartCoroutine("ExitCleanDelay");
        }
    }


    IEnumerator ExitCleanDelay()
    {
        yield return new WaitForSeconds(2f);
        panel.SetActive(false);
    }
}
