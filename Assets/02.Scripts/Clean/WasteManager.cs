using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WasteManager : MonoBehaviour
{
    private InGameManager GM;
    private WasteBin wasteBin;
    private WasteObject wasteObject;

    public GameObject panel;
    public GameObject can;
    public GameObject paperCup;
    public GameObject clear;

    public GameObject[] boolCan;
    public GameObject[] boolPaper;

    public Transform wasteRoot;

    private int boolCanSize;
    private int boolPaperSize;

    public bool complete;

    public int i, j;

    private void Start()
    {
        GM = GameObject.Find("InGameManager").GetComponent<InGameManager>();
        boolCan = GameObject.FindGameObjectsWithTag("trash_can");
        boolPaper = GameObject.FindGameObjectsWithTag("trash_paperCup");

        boolCanSize = boolCan.Length;
        boolPaperSize = boolPaper.Length;
    }

    private void Update()
    {
        if (panel.activeSelf == true)
        {
            complete = false;
            clear.SetActive(false);
        }
        else if (panel.activeSelf == false)
        {
            complete = true;
            clear.SetActive(true);
        }

        //Debug.Log(complete);

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

    void ResetWaste()
    {
        i = 0; j = 0;
        for (int k=0;k< wasteRoot.childCount; k++)
        {
            var wasteObject = wasteRoot.GetChild(k).GetComponent<WasteObject>();
            wasteObject.ResetObject();
        }

    }


    IEnumerator ExitCleanDelay()
    {
        GM.CleanClear();
        yield return new WaitForSeconds(2f);
        complete = true;
        ResetWaste();
        clear.SetActive(false);
        panel.SetActive(false);
    }
}
