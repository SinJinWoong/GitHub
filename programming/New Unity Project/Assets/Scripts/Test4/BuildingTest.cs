using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTest : MonoBehaviour {

    // 자기 밑에있는 타일의 레이어값을 가져온다.
    //캐릭터도 마찬가지 근데 캐릭터는 계속해서 가져오는거로해야할듯

    void Start () {
		
	}
	
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Land")
        {

            gameObject.GetComponent<SpriteRenderer>().sortingOrder
                = col.GetComponent<SpriteRenderer>().sortingOrder + 101;

            col.GetComponent<SpriteRenderer>().sortingOrder -= 100;
            col.GetComponent<PolygonCollider2D>().enabled = false;

        }
    }
}
