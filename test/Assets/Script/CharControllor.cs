using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControllor : MonoBehaviour {

    public Sprite[] sprite;
    SpriteRenderer spriteRenderer;
    public float speed;
    float h, v;
    // Use this for initialization
    void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        sprite = new Sprite[4];
        for (int i = 0; i < 2; i++)
        {
            sprite[i] = Resources.Load<Sprite>("Char/1/c_a" + (i + 1).ToString());
            sprite[i+2] = Resources.Load<Sprite>("Char/1/c_b" + (i + 1).ToString());
        }
        speed = 10f;

        
    }
	
	// Update is called once per frame
	void Update () {

        CMove();
    }

    void CMove()
    {
        h = Input.GetAxisRaw("Horizontal")  * speed * Time.deltaTime;
        v = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        transform.Translate(h, v, 0);

        ChangeSprite();
    }

    void ChangeSprite()
    {
        if (h > 0) //오른쪽
            spriteRenderer.sprite = sprite[1];
        else if(h < 0) //왼쪽
            spriteRenderer.sprite = sprite[0];

        if (v > 0 && h > 0) //오른쪽 위
            spriteRenderer.sprite = sprite[3];
        else if(v > 0 && h < 0) // 왼쪽 위
            spriteRenderer.sprite = sprite[2];

        if (v < 0 && h > 0) //오른쪽 아래
            spriteRenderer.sprite = sprite[1];
        else if (v < 0 && h < 0) // 왼쪽 아래
            spriteRenderer.sprite = sprite[0];


        if(spriteRenderer.sprite == sprite[0]) //왼쪽을 보고 있을 때 위를 눌렀을 때
            if(v > 0)
                spriteRenderer.sprite = sprite[2];

        if (spriteRenderer.sprite == sprite[1]) //오른쪽을 보고 있을 때 위를 눌렀을 때
            if (v > 0)
                spriteRenderer.sprite = sprite[3];

        if (spriteRenderer.sprite == sprite[2]) //왼쪽을 보고 있을 때 아래를 눌렀을 때
            if (v < 0)
                spriteRenderer.sprite = sprite[0];

        if (spriteRenderer.sprite == sprite[3]) //오른쪽을 보고 있을 때 아래를 눌렀을 때
            if (v < 0)
                spriteRenderer.sprite = sprite[1];

    }

}
