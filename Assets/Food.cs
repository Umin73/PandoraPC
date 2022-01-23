using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public RectTransform UIgroup; //UI담을 변수

    PlayerMove enterPlay;
    public GameObject[] foodObj; //음식 프리펩으로
    public Image[] foodPos; //음식 카트 몇 번째에 담을것인지
    public GameObject cookingPanel;
    public GameObject notCookPanel;
    public Image cookGuage;

    public float maxCookTime;
    private float curCookTime;
    private bool isCooking;


    private void Start()
    {
        cookingPanel.SetActive(false);
        notCookPanel.SetActive(false);
        isCooking = false;
        curCookTime = 0;
    }

    private void Update()
    {
        if (isCooking)
        {
            curCookTime += Time.deltaTime; //요리 시간이 isCooking == true 때만 돌아가게 할건데 이게 맞는지..?
            cookGuage.fillAmount = curCookTime / maxCookTime;
            if (curCookTime == maxCookTime)
            {
                isCooking = false;
                //음식 인벤토리에 담기
            }
        }
        else
        {
            curCookTime = 0;
        }
    }

    public void Enter(PlayerMove player)
    {
        enterPlay = player;
        UIgroup.anchoredPosition = Vector2.zero; //화면 중앙에 오도록
    }

    public void Exit()
    {
        UIgroup.anchoredPosition = Vector2.down * 1000;
    }
    public void Cooking(int foodIndex, int curCartIndex, int maxCartIndex) //음식의 지정된 인덱스 번호, 음식인벤토리(카트)의 유동적인 인덱스번호
    {
        if(curCartIndex - 1 < maxCartIndex)
        {
            cookingPanel.SetActive(true);
            isCooking = true;
            if (isCooking == false) cookingPanel.SetActive(false);
        }
        else
        {
            isCooking = false;

            //음식을 담을 공간이 없다고 뜨기
            notCookPanel.SetActive(true);

            //판넬의 나가기 버튼(ExitNotCook)을 따로 눌러야 창 닫힘
        }                                                                
    }

    public void ExitCooking()
    {
        cookingPanel.SetActive(false);
        isCooking = false; //조리하던 것 강제 종료
    }

    public void ExitNotCook()
    {
        notCookPanel.SetActive(false);
    }
   
}
