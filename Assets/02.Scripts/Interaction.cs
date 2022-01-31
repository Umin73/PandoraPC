using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject UIgroup;
    public void Enter()
    {
        UIgroup.SetActive(true);
    }

    public void Exit()
    {
        UIgroup.SetActive(false);
    }
}
