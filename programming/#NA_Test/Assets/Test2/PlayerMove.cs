using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{

    public int speed = 10; //스피드 
    public int jumpPower = 2; //점프높이 

    public bool isJumping; // 점프를 하고있는가?

    Vector3 movement;
    float xMove;
    float yMove;

    Rigidbody2D rig;

    public GameObject YouDied = null;
    public bool Die = false;

    bool _Right = true; // 시선

    public Test_2_LineCreate_2 lineCreate;

    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (!Die)
        {
            Run();
        }
        if (Input.GetKey(KeyCode.W) && !isJumping && !Die)
        {
            Jump();
        }
    }

    void Run()
    {
            if (!lineCreate.kenaz)
        {
            xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //x축으로 이동할 양 
            if (xMove != 0)
            {
                if ((xMove > 0 && _Right) || (xMove < 0 && !_Right))
                {
                    Flip();  // 시선 변경
                }
            }
            gameObject.transform.Translate(new Vector3(xMove, yMove, 0));  //이동
        }
           
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        _Right = !_Right;
    }

    void OnCollisionEnter2D(Collision2D coll) // C#, type first, name in second
    {
        if (coll.gameObject.tag == "Ground" )
        {
            isJumping = false;
        }
    }

    //  void OnCollisionExit2D(Collision2D coll) // C#, type first, name in second
    //{
    //    if (coll.gameObject.tag == "Ground" )
    //    {
    //        isJumping = true;
    //    }
    //}

        void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Save")
        {
            lineCreate.lineNumberCounter.CreateLineCount_2();
        }
    }
    void Jump()
    {
        isJumping = true;

        rig.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

}
