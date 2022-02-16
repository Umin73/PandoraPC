using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ElecButton : MonoBehaviour
{
    private ElecManager elecManager;

    public Image image;
    public Sprite up;
    public Sprite down;

    public bool isDown;

    public void DOWN() //랜덤번째 차단기가 내려가 있는 상태
    {
        isDown = true;
        image.sprite = down;
    }

    public void UP()
    {
        isDown = false;
        image.sprite = up;
    }

    public void OnClick()
    {

        if (isDown)
        {
            Debug.Log("차단기 올리기");
            image.sprite = up;
            isDown = false;
        }
        else
        {
            Debug.Log("차단기 내리기");
            image.sprite = down;
            isDown = true;
        }
    }

}
