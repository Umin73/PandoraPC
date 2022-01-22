using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float x, y;
    private int direction;
    private bool isMove;
    private bool isCook;
    private bool isW, isA, isS, isD;
    
    private GameObject nearObject; //충돌한 오브젝트
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
        isMove = false;
        isW = false;
        isA = false;
        isS = false;
        isD = false;
    }

    // Update is called once per frame
    void Update()
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

    void FixedUpdate()
    {
        if(isMove)
        {
          rb.MovePosition(rb.position + new Vector2(x,y)*Time.deltaTime);
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


        if(x >= 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else
        {
            transform.localScale = new Vector3(-1,1,1);
        }

    }
    
     void Interaction()
    {
        if(nearObject.tag == "Cook")
        {
            Food food = nearObject.GetComponent<Food>();
            food.Enter(this);
            isCook = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Cook")
            nearObject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Cook")
        {
            Food food = nearObject.GetComponent<Food>();
            food.Exit();
            nearObject = null;
            isCook = false;
        }
    }
}
