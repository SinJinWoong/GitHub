using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAlphaTest2 : MonoBehaviour {

    public GameObject papa;

	void Start () {
		
	}
	
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            Color color = papa.transform.GetComponent<SpriteRenderer>().color;
            color.a = 0.5f;
            papa.transform.GetComponent<SpriteRenderer>().color = color;

        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Color color = papa.transform.GetComponent<SpriteRenderer>().color;
            color.a = 1f;
            papa.transform.GetComponent<SpriteRenderer>().color = color;
        }
    }
}
