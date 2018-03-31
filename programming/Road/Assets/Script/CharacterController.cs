using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float moveSpeed;
    public bool moveJump, moveRope;
    public float moveX, moveY;

    public Sprite sprite1, sprite2;


    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        InIt();

    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (moveRope)
            moveJump = true;
    }

    void InIt()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
        moveJump = false;
        moveRope = false;
    }

    void Move()
    {
        moveX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        moveY = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        if (moveRope)
            transform.Translate(moveX, moveY, 0);

        else
            transform.Translate(moveX, 0, 0);


        if (moveX > 0) //오른쪽
        {
            spriteRenderer.sprite = sprite2;
        }
        else if (moveX < 0) //왼쪽
        {
            spriteRenderer.sprite = sprite1;
        }

        if (!moveJump)
        {
            Jump();
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(transform.up * 300);
            moveJump = true;

        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.layer == 8) //바닥 레이어
        {
            moveJump = false;
        }

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.layer == 9) //로프 레이어
        {
            moveRope = true;
            rb.gravityScale = 0;
        }
        else if (col.gameObject.layer != 9)
        {
            moveRope = false;
            rb.gravityScale = 1;
        }
    }

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.gameObject.layer == 9) //로프 레이어
    //    {
    //        moveRope = true;
    //        rb.gravityScale = 0;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D col)
    //{
    //    if (col.gameObject.layer == 9)
    //    {
    //        moveRope = false;
    //        rb.gravityScale = 1;
    //    }
    //}

}
