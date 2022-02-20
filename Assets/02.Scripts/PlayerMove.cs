using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private InGameManager GM;
    //public GameObject icon;
    private Rigidbody2D rb;
    public float speed;
    private float x, y;
    private int direction;
    private bool isMove;
    private bool isW, isA, isS, isD;
    private bool isObject, isInter, isComputer;

    //패널 예시
    //public GameObject panel;

    
    

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("InGameManager").GetComponent<InGameManager>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        
        Setup();
    }

    void Setup()
    {
        isInter = false;
        isObject = false;
        isComputer = false;
        isMove = false;
        isW = false;
        isA = false;
        isS = false;
        isD = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && isObject)
        {
            Interaction();
        }

        if(!isInter)
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                isW = true;
                isMove = true;
            }
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                isA = true;
                isMove = true;
            }
            if(Input.GetKey(KeyCode.DownArrow))
            {
                isS = true;
                isMove = true;
            }
            if(Input.GetKey(KeyCode.RightArrow))
            {
                isD = true;
                isMove = true;
            }

            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                SetDirection();
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SetDirection();
            }
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
            SetDirection();
            }
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                SetDirection();
            }

            if(Input.GetKeyUp(KeyCode.UpArrow))
            {
                isW =false;
                isMove = false;
                SetDirection();
            }
            if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                isA = false;
                isMove = false;
                SetDirection();
            }
            if(Input.GetKeyUp(KeyCode.DownArrow))
            {
                isS = false;
                isMove = false;
                SetDirection();
            }
            if(Input.GetKeyUp(KeyCode.RightArrow))
            {
                isD = false;
                isMove = false;
                SetDirection();
            }
        }
    }

    void FixedUpdate()
    {
        if(isMove && !isInter)
        {
          rb.MovePosition(rb.position + new Vector2(x,y)*Time.deltaTime);
          gameObject.GetComponent<Animator>().speed = 1.0f;
        }
        else
        {
            gameObject.GetComponent<Animator>().speed = 0.0f;
        }
    }


    void SetDirection() //방향설정
    {
        if(isW && !isA && !isS && !isD) // only w
        {
            direction = 90;
        }
        else if(!isW && isA && !isS && !isD) // only a
        {
            direction = 180;
        }
        else if(!isW && !isA && isS && !isD) // only a
        {
            direction = 270;
        }
        else if(!isW && !isA && !isS && isD) // only d
        {
            direction = 0;
        }

        else if(isW && !isA && !isS && isD) // w & d
        {
            direction = 45;
        }
        else if(isW && isA && !isS && !isD) // w & a
        {
            direction = 135;
        }
        else if(!isW && isA && isS && !isD) // a & s
        {
            direction = 225;
        }
        else if(!isW && !isA && isS && isD) // d & s
        {
            direction = 315;
        }


        x = speed * Mathf.Cos(direction * Mathf.Deg2Rad);
        y = speed * Mathf.Sin(direction * Mathf.Deg2Rad);


        if(x > 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z);
        }
        else if(x < 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1 ,transform.localScale.y ,transform.localScale .z);
        }

    }
    
    //예시
    void Interaction()
    {
        isInter = true;
        isMove = false;
        GM.PanelActive();
    }


    public void DeActInter()
    {
        if(isInter)
        {
            isInter = false;
            isMove = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Cook"))
        {
            isObject = true;
            GM.CookIconActive(true);
        }
        else if(collision.CompareTag("Electro"))
        {
            isObject = true;
            GM.ElecIconActive(true);
        }
        else if(collision.CompareTag("Clean"))
        {
            isObject = true;
            GM.CleanIconActive(true);
        }
        else if(collision.CompareTag("Storage"))
        {
            isObject = true;
            GM.StorageIconActive(true);
        }
        else if (collision.CompareTag("Counter"))
        {
            isObject = true;
            GM.CounterIconActive(true);
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cook"))
        {
            isObject = false;
            GM.CookIconActive(false);
        }
        else if(collision.CompareTag("Electro"))
        {
            isObject = false;
            GM.ElecIconActive(false);
        }
        else if(collision.CompareTag("Clean"))
        {
            isObject = false;
            GM.CleanIconActive(false);
        }
        else if(collision.CompareTag("Storage"))
        {
            isObject = false;
            GM.StorageIconActive(false);
        }
        
        else if (collision.CompareTag("Counter"))
        {
            isObject = false;
            GM.CounterIconActive(false);
        }
    }

}
