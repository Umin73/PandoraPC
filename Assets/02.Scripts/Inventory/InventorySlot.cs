using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [HideInInspector] public FoodProperty food;
    [HideInInspector] public Cook cook;

    public Image image;

    public void SetFood(FoodProperty _food)
    {
        this.food = _food;

        if (_food == null)
        {
            image.enabled = false;
            gameObject.name = "Empty";
        }
        else
        {
            image.enabled = true;
            gameObject.name = food.foodName;
            image.sprite = food.foodSprite;
        }
    }
}
