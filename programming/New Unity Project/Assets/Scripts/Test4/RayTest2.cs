using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest2 : MonoBehaviour {

    public float color = 0;
    public RaycastHit2D[] h_rd;
    public RaycastHit2D[] h_up;


    public int orderinLayer;
    Vector3 rightdown;

    public GameObject h_1; //정보주는 근처친구
    void Awake()
    {
    }

    // Update is called once per frame
    void Update () {
        Debug.DrawRay(transform.position, rightdown, Color.magenta);

    }

    public IEnumerator rayTest2()
    {
       
        // 근처에 있는 친구한테서 정보 받아오기
           rightdown = new Vector3(0.7f, -0.4f, 0).normalized;
           h_rd = Physics2D.RaycastAll(transform.position, rightdown,1f); // orderinLayer 숫자랑 color 받아오기
           h_1 = h_rd[1].transform.gameObject;
           color = h_rd[1].transform.GetComponent<SpriteRenderer>().color.r * 255;
           orderinLayer = h_rd[1].transform.GetComponent<SpriteRenderer>().sortingOrder;

        // 받아온 정보를 바탕으로 다른친구들한테 정보 넘겨주기
        // 이친구는 오른쪽친구들한테 같은 정보를 차례대로 넘겨주고 그 친구들이 위아래로 다른 정보를 또 전해준다.


        h_up = Physics2D.RaycastAll(transform.position, transform.up);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = orderinLayer;
        //전부 1씩 차이나기 orderinLayer++ 
        color += 5;

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


    yield break;

    }
}
