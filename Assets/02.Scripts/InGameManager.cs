using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    public GameObject cookIcon, elecIcon, cleanIcon, storageIcon, counterIcon;
    public GameObject cookPanel, elecPanel, cleanPanel, storagePanel, counterPanel;
    public GameObject EM, CM, SM, WM;
    public GameObject scoreText, gameoverPanel;
    bool canCook, canElec, canClean, canStorage, canCounter;
    bool isElec, isClean, isStorage, isCounter;
    float elecTimer, cleanTimer, storageTimer, counterTimer;
    public GameObject complainGage;
    public float maxComplain;
    private float complainVar;

    private PlayerMove PM;

    private float timescore;

    bool isGameOver;

    public List<GameObject> computers;


    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.Find("Player").GetComponent<PlayerMove>();
        canCook = false;
        canElec = false;
        canClean = false;
        canStorage = false;
        canCounter = false;
        isGameOver = false;
        elecTimer =0;
        cleanTimer = 0;
        storageTimer = 0;
        counterTimer = 0;
        complainGage.GetComponent<Image>().fillAmount = complainVar / maxComplain;

        StartCoroutine(ComeGuest());
        StartCoroutine(EventSystem());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            ClosePanel();
        }

        if(!isGameOver)
            timescore += Time.deltaTime;

        if(isElec)
        {
            elecIcon.SetActive(true);
            elecTimer += Time.deltaTime;
        }
        else
        {
            elecIcon.SetActive(false);
            elecTimer = 0;
        }

        if(isClean)
        {
            cleanIcon.SetActive(true);
            cleanTimer += Time.deltaTime;
        }
        else
        {
            cleanIcon.SetActive(false);
            cleanTimer = 0;
        }

        if(isCounter)
        {
            counterIcon.SetActive(true);
            counterTimer += Time.deltaTime;
        }
        else
        {
            counterIcon.SetActive(false);
            counterTimer = 0;
        }
        
        if(isStorage)
        {
            storageIcon.SetActive(true);
            storageTimer += Time.deltaTime;
        }
        else
        {
            storageIcon.SetActive(false);
            storageTimer = 0;
        }

        if(elecTimer >= 15f)
        {
            AddComplain();
            isElec = false;
        }

        if(cleanTimer >= 15f)
        {
            AddComplain();
            isClean = false;
        }

        if(storageTimer >= 15f)
        {
            AddComplain();
            isStorage = false;
        }

        if(counterTimer >= 15f)
        {
            AddComplain();
            isCounter = false;
        }
    }

    public void ElecClear()
    {
        isElec = false;
        PM.DeActInter();
    }

    public void CleanClear()
    {
        isClean = false;
        PM.DeActInter();
    }

    public void StorageClear()
    {
        isStorage =false;
        PM.DeActInter();
    }

    public void CounterClear()
    {
        isCounter = false;
        PM.DeActInter();
    }

    IEnumerator ComeGuest()
    {
        int rnd;
        int cooltime;
        while(true)
        {
            rnd = Random.Range(0, computers.Count);
            cooltime = Random.Range(5, 11);

            computers[rnd].GetComponent<Computer>().SetGuest();

            yield return new WaitForSeconds(cooltime);
        }
    }

    IEnumerator EventSystem()
    {
        int rnd;
        int cooltime;
        while(true)
        {
            cooltime = Random.Range(10,21);
            
            rnd = Random.Range(0,4);

            if(rnd == 0) //Elec
            {
                isElec = true;
            }
            else if(rnd == 1) // Clean
            {
                isClean = true;
            }
            else if(rnd == 2) // Storage
            {
                isStorage = true;
            }
            else if(rnd == 3) // counter
            {
                isCounter = false;
            }


            yield return new WaitForSeconds(cooltime);
        }
    }

    

    void CheckGameOver()
    {
        if(complainVar >= maxComplain)
        {
            isGameOver = true;
            gameoverPanel.SetActive(true);
            scoreText.GetComponent<Text>().text = "Score : " + timescore.ToString();
        }
        
    }

    public void CookIconActive(bool onoff)
    {
        if(onoff == true)
        {
            cookIcon.SetActive(true);
            canCook = true;
        }
        else
        {
            cookIcon.SetActive(false);
            canCook = false;
        }
    }

    public void ElecIconActive(bool onoff)
    {
        if(onoff == true)
        {
            //elecIcon.SetActive(true);
            canElec = true;
        }
        else
        {
            //elecIcon.SetActive(false);
            canElec = false;
        }
    }

    public void CleanIconActive(bool onoff)
    {
        if(onoff == true)
        {
            //cleanIcon.SetActive(true);
            canClean = true;
        }
        else
        {
            //cleanIcon.SetActive(false);
            canClean = false;
        }
    }

    public void StorageIconActive(bool onoff)
    {
        if(onoff == true)
        {
            //storageIcon.SetActive(true);
            canStorage = true;
        }
        else
        {
            //storageIcon.SetActive(false);
            canStorage = false;
        }
    }

    public void CounterIconActive(bool onoff)
    {
        if(onoff == true)
        {
            //counterIcon.SetActive(true);
            canCounter = true;
        }
        else
        {
            //counterIcon.SetActive(false);
            canCounter = false;
        }
    }

    public void PanelActive()
    {
        if(canCook)
        {
            cookPanel.SetActive(true);
        }
        else if(canElec && isElec)
        {
            elecPanel.SetActive(true);
            EM.GetComponent<ElecManager>().ResetElec();
        }
        else if(canClean && isClean)
        {
            cleanPanel.SetActive(true);
            WM.GetComponent<WasteManager>().ResetWaste();
        }
        else if(canStorage && isStorage)
        {
            storagePanel.SetActive(true);
            //SM.GetComponent<SellByData>().Reset();
        }
        else if(canCounter && isCounter)
        {
            counterPanel.SetActive(true);
            //CM.GetComponent<Order>().ResetQuantity();
        }
    }

    void ClosePanel()
    {
        cookPanel.SetActive(false);
        elecPanel.SetActive(false);
        cleanPanel.SetActive(false);
        storagePanel.SetActive(false);
        counterPanel.SetActive(false);
        PM.DeActInter();
    }

    public void AddComplain()
    {
        complainVar += 1;
        complainGage.GetComponent<Image>().fillAmount = complainVar / maxComplain;

        CheckGameOver();
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
