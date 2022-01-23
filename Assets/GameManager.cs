using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMove player;
    //public Guest guest;
    public GameObject gamePanel; //인게임 판넬

    public Text timeText;
    public Text stageText;
    public Image Cart1;
    public Image Cart2;
    public Image Cart3;
    public Image Cart4;
    public Image Cart5;
    public Image AngryGuage; //불만 게이지

    private int stage; //n번째 스테이지
    private float playTime; //남은 시간
    private bool isGameOver; //게임 오버 상태

    void Start()
    {
        //gamePanel.SetActive(false); 
        isGameOver = false;
        playTime = 300;
        AngryGuage = GetComponent<Image>();
    }

    void Update()
    {
        if (!isGameOver)
        {
            playTime -= Time.deltaTime;
        }
        else
        {

        }
    }

    private void LateUpdate()
    {
        int min = (int)(playTime / 60);
        int sec = (int)(playTime % 60);
        timeText.text = string.Format("{0:00}", min) + ":" + string.Format("{0:00}", sec);

        //AngryGuage.fillAmount = guest.curAngry / guest.MaxAngry;
    }

    public void Cook()
    {
        
    }

    public void EndGame()
    {
        isGameOver = true;

    }
}
