using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileMouse : MonoBehaviour
{
    private static TileMouse instance = null;

    public static TileMouse Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(TileMouse)) as TileMouse;
                if (instance == null)
                {
                    Debug.LogError("no active ManagerCenter object");
                }
            }
            return instance;
        }
    }

    public SpriteRenderer spriteRenderer;
    //public SpriteRenderer hitSpriteRendererG;
    public SpriteRenderer hitSpriteRendererS;
    public SpriteRenderer hitSpriteRendererSt;
    public Sprite sprite;
    public Sprite spriteSt;
    public Image ImageS;
    public Image ImageSt;

    public LayerMask layerMask;

    Vector2 currentTile;
    // Use this for initialization
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        hitSpriteRendererS = gameObject.GetComponent<SpriteRenderer>();
        hitSpriteRendererSt = gameObject.GetComponent<SpriteRenderer>();
        //spriteS = gameObject.GetComponent<Sprite>();
        //spriteSt = gameObject.GetComponent<Sprite>();
    }

    // Update is called once per frame
    void Update()
    {
        MonthCheck();

        MouseDown();
    }

    void MonthCheck()
    {
        RayTIle();

    }

    void RayTIle()
    {
        RaycastHit2D[] hits;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hits = Physics2D.RaycastAll(pos, Vector2.zero, Mathf.Infinity);
        {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];
                if (hit.collider != null)
                {
                    currentTile.x = hit.collider.gameObject.transform.position.x;
                    currentTile.y = hit.collider.gameObject.transform.position.y;
                    transform.position = currentTile;
                    spriteRenderer.sprite = sprite;
                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("SoilTile"))
                    {
                        hitSpriteRendererS = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                    }
                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("StuctureTile"))
                    {
                        hitSpriteRendererSt = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                    }
                }
            }
        }
    }



    void MouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (spriteRenderer.sprite != null)
            {
                if (ImageS.sprite != null)
                 hitSpriteRendererS.sprite = ImageS.sprite;

                if(ImageSt.sprite != null)
                    hitSpriteRendererSt.sprite = ImageSt.sprite;
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (spriteRenderer.sprite != null)
            {
                if (ImageS.sprite != null)
                    hitSpriteRendererS.sprite = ImageS.sprite;

                if (ImageSt.sprite != null)
                    hitSpriteRendererSt.sprite = ImageSt.sprite;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            spriteRenderer.sprite = null;
            sprite = null;
        }
    }

}