using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{
    private InGameManager GM;
    //public GameObject IconPanel;
    public GameObject customer;
    public GameObject trash;
    public GameObject trashGage;
    public float trashTimeLimit;
    private float trashTimeCount;
    private bool isTrash;
    
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("InGameManager").GetComponent<InGameManager>();
        isTrash = false;
        trashTimeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTrash)
        {
            trashTimeCount += Time.deltaTime;
            trashGage.GetComponent<Image>().fillAmount = (trashTimeLimit-trashTimeCount)/trashTimeLimit;
        }

        if(trashTimeLimit <= trashTimeCount)
        {
            FailedTrash();
        }

        // 쓰레기 발생 테스트용 (T)
        if(Input.GetKey(KeyCode.T))
        {
            SetTrash();
        }
    }

    void SetTrash()
    {
        trash.SetActive(true);
        trashGage.SetActive(true);
        isTrash = true;
    }

    void FailedTrash()
    {
        trash.SetActive(false);
        trashGage.SetActive(false);
        isTrash = false;
        trashTimeCount = 0;

        GM.AddComplain();
    }
}
