using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public float speed = 1; //스피드 
    float xMove, yMove;


    bool _Right = true; // 시선
    bool theScale;

    public bool movestop = false;

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); //뒤집기용

        if (h != 0)
        {
            if ((h > 0 && _Right) || (h < 0 && !_Right))
            {
                Flip();  // 시선 변경
            }
        }
        Run();

    }

    void Run()
    {
        xMove = 0;
        yMove = 0;

      
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            xMove = speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            xMove = -speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            yMove = speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            yMove = -speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            xMove = -0.65f * speed * Time.deltaTime;
            yMove = 0.4f * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            xMove = -0.65f * speed * Time.deltaTime;
            yMove = -0.4f * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            xMove = 0.65f * speed * Time.deltaTime;
            yMove = 0.4f * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            xMove = 0.65f * speed * Time.deltaTime;
            yMove = -0.4f * speed * Time.deltaTime;
        }

        this.transform.Translate(new Vector3(xMove, yMove,0 ));
        
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        _Right = !_Right;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Land")
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder
                = col.GetComponent<SpriteRenderer>().sortingOrder + 102;
        }
    }

 
}