using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{
    private FoodDB foodDB;
    private InGameManager GM;
    //public GameObject IconPanel;
    public GameObject customer;
    public GameObject trash, gagePrefab;
    private GameObject trashGage;
    public GameObject GuestImg;
    public float trashTimeLimit;
    private float trashTimeCount;
    private bool isTrash;
    private bool isGuest;

    private bool isFood;

    public GameObject OrderIcon;

    public float minStayTime;
    public float maxStayTime;

    private float staytime;
    private float staytimeCount;

    public float foodLimit;
    private float foodTimeCount;

    private int foodNo;

    public GameObject FoodIcon;
    
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("InGameManager").GetComponent<InGameManager>();
        foodDB = GameObject.Find("FoodDB").GetComponent<FoodDB>();

        isTrash = false;
        trashTimeCount = 0;

        isGuest = false;
        isFood = false;
        staytimeCount = 0;
        foodTimeCount = 0;

        trashGage = Instantiate(gagePrefab, transform.position, Quaternion.identity, GameObject.Find("IconPanel").transform);
        trashGage.SetActive(false);
        trashGage.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 0.6f, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if(isTrash)
        {
            trashTimeCount += Time.deltaTime;
            trashGage.GetComponent<Image>().fillAmount = (trashTimeLimit-trashTimeCount)/trashTimeLimit;
        }

        if(isFood)
        {
            foodTimeCount += Time.deltaTime;
            trashGage.GetComponent<Image>().fillAmount = (foodLimit-foodTimeCount)/foodLimit;
        }

        if(foodLimit <= foodTimeCount)
        {
            FailOrder();
        }

        if(isGuest && !isFood)
        {
            staytimeCount += Time.deltaTime;
        }

        if(staytimeCount > staytime)
        {
            SetTrash();
        }

        if(trashTimeLimit <= trashTimeCount)
        {
            FailedTrash();
        }



    //test
    /*
        if(Input.GetKey(KeyCode.T))
        {
            SetGuest();
        }
        */
    }

    public void SetGuest()
    {
        
        GuestImg.SetActive(true);

        //check food order

        int rnd = Random.Range(1,101);

        if(rnd <= 20)
        {
            OrderFood();
        }

        staytime = Random.Range(minStayTime, maxStayTime);

        isGuest = true;
    }

    void OrderFood()
    {
        isFood = true;
        OrderIcon.SetActive(true);
        trashGage.SetActive(true);

        foodNo = Random.Range(0, foodDB.foods.Count);

        FoodIcon.GetComponent<SpriteRenderer>().sprite = foodDB.foods[foodNo].foodSprite;
        FoodIcon.SetActive(true);
    }

    void FailOrder()
    {
        isFood = false;
        
        OrderIcon.SetActive(false);
        trashGage.SetActive(false);

        foodTimeCount = 0;

        GM.AddComplain();
    }

    void SetTrash()
    {

        staytimeCount = 0;
        customer.SetActive(false);
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

    public void ClearOrder()
    {
        isFood = false;
        
        OrderIcon.SetActive(false);
        trashGage.SetActive(false);

        foodTimeCount = 0;
    }

    public void ClearTrash()
    {
        trash.SetActive(false);
        trashGage.SetActive(false);
        isTrash = false;
        trashTimeCount = 0;
    }
}
