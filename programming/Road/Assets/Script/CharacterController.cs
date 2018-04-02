using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private static CharacterController instance = null;

    public static CharacterController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(CharacterController)) as CharacterController;
            }
            return instance;
        }
    }



    public float moveSpeed;
    public bool moveJump, moveRope;
    public float moveX, moveY;

    public Sprite sprite1, sprite2;


    BoxCollider2D charBoxCol;
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

        if(moveY > 0 )
        {
            Physics2D.IgnoreLayerCollision(8,11,true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(8,11,false);

        }
    }

    void InIt()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        charBoxCol = GetComponent<BoxCollider2D>();
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

        if (!moveJump && !moveRope)
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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 8 || col.gameObject.layer == 9) //바닥 레이어
        {
            moveJump = false;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.layer == 9) //로프 레이어
        {
            moveRope = true;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        else if (col.gameObject.layer != 9)
        {
            moveRope = false;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

}
