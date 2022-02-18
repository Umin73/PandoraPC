using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public GameObject cookIcon, elecIcon, cleanIcon, storageIcon;
    public GameObject cookPanel, elecPanel, cleanPanel, storagePanel;
    public GameObject scoreText, gameoverPanel;
    bool canCook, canElec, canClean, canStorage;
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
        isGameOver = false;
        complainGage.GetComponent<Image>().fillAmount = complainVar / maxComplain;

        StartCoroutine(ComeGuest());
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
    }

    IEnumerator ComeGuest()
    {
        while(true)
        {
            int rnd = Random.Range(0, computers.Count);
            int cooltime = Random.Range(5, 11);

            computers[rnd].GetComponent<Computer>().SetGuest();

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
            elecIcon.SetActive(true);
            canElec = true;
        }
        else
        {
            elecIcon.SetActive(false);
            canElec = false;
        }
    }

    public void CleanIconActive(bool onoff)
    {
        if(onoff == true)
        {
            cleanIcon.SetActive(true);
            canClean = true;
        }
        else
        {
            cleanIcon.SetActive(false);
            canClean = false;
        }
    }

    public void StorageIconActive(bool onoff)
    {
        if(onoff == true)
        {
            storageIcon.SetActive(true);
            canStorage = true;
        }
        else
        {
            storageIcon.SetActive(false);
            canStorage = false;
        }
    }

    public void PanelActive()
    {
        if(canCook)
        {
            cookPanel.SetActive(true);
        }
        else if(canElec)
        {
            elecPanel.SetActive(true);
        }
        else if(canClean)
        {
            cleanPanel.SetActive(true);
        }
        else if(canStorage)
        {
            storagePanel.SetActive(true);
        }
    }

    void ClosePanel()
    {
        cookPanel.SetActive(false);
        elecPanel.SetActive(false);
        cleanPanel.SetActive(false);
        storagePanel.SetActive(false);
        PM.DeActInter();
    }

    public void AddComplain()
    {
        complainVar += 1;
        complainGage.GetComponent<Image>().fillAmount = complainVar / maxComplain;

        CheckGameOver();
    }
}
