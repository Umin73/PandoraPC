using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDragSlot : MonoBehaviour
{
    static public InventoryDragSlot instance;

    public InventorySlot dragSlot;

    [SerializeField] private Image foodImage;

    private void Start()
    {
        instance = this;
    }

    public void SetDragImage(Image _foodImage)
    {
        foodImage.sprite = _foodImage.sprite;
        setColor(1);
    }

    public void setColor(float _alpha)
    {
        Color color = foodImage.color;
        color.a = _alpha;
        foodImage.color = color;
    }
}
