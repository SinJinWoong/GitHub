using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAlphaTest : MonoBehaviour {

    public GameObject target;
    public int order;
	void Start () {
		
	}
	
	void Update () {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "enemy")
        {
            Color color = col.transform.GetComponent<SpriteRenderer>().color;
            color.a = 0.5f;
            col.transform.GetComponent<SpriteRenderer>().color = color;

            order = col.GetComponent<SpriteRenderer>().sortingOrder;
            col.GetComponent<SpriteRenderer>().sortingOrder = 5000;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "enemy")
        {
            Color color = col.transform.GetComponent<SpriteRenderer>().color;
            color.a = 1f;
            col.transform.GetComponent<SpriteRenderer>().color = color;
            col.GetComponent<SpriteRenderer>().sortingOrder = order;
        }
    }
}
