using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public RectTransform UIgroup; //UI담을 변수

    PlayerMove enterPlay;
    public GameObject[] foodObj;
    public Transform[] foodPos;

    public void Enter(PlayerMove player)
    {
        enterPlay = player;
        UIgroup.anchoredPosition = Vector2.zero; //화면 중앙에 오도록
    }

    public void Exit()
    {
        UIgroup.anchoredPosition = Vector2.down * 1000;
    }
    public void Cooking(int foodIndex, int cartIndex) //음식의 지정된 인덱스 번호, 음식인벤토리(카트)의 유동적인 인덱스번호
    {
        
    }

    void Update()
    {
        
    }
}
