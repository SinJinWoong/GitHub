using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour {

    public RaycastHit2D[] h_up;
    public int orderinLayer = 1000;
    public float color = 0;

    public RayTest2 test2;

    void Awake () {

        h_up = Physics2D.RaycastAll(transform.position, transform.up);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = orderinLayer;

        for (int i = 0; i < h_up.Length; i++)
        {
            if (h_up[i].transform.tag == "Land")
            {
                h_up[i].transform.GetComponent<SpriteRenderer>().color = new Color(color / 255, color / 255, color / 255);
                h_up[i].transform.GetComponent<SpriteRenderer>().sortingOrder = orderinLayer -= 2;

                // 오른쪽
                RaycastHit2D[] h_right = Physics2D.RaycastAll(h_up[i].transform.position, h_up[i].transform.right);
                for (int a = 0; a < h_right.Length; a++)
                {
                    if (h_right[a].transform.tag == "Land")
                    {
                        h_right[a].transform.GetComponent<SpriteRenderer>().color = new Color(color / 255, color / 255, color / 255);
                        h_right[a].transform.GetComponent<SpriteRenderer>().sortingOrder = orderinLayer;
                    }
                }

                // 왼쪽
                RaycastHit2D[] h_left = Physics2D.RaycastAll(h_up[i].transform.position, -h_up[i].transform.right);
                for (int a = 0; a < h_left.Length; a++)
                {
                    if (h_left[a].transform.tag == "Land")
                    {
                        h_left[a].transform.GetComponent<SpriteRenderer>().color = new Color(color / 255, color / 255, color / 255);
                        h_left[a].transform.GetComponent<SpriteRenderer>().sortingOrder = orderinLayer;
                    }
                }
                color += 10;
            }
        }

       // StartCoroutine(test2.rayTest2());
    }

    void Update () {

        Debug.DrawRay(transform.position, transform.up, Color.magenta);
	}

}
