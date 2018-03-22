using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTest2 : MonoBehaviour {

    public int number = 2;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Land")
        {
           col.GetComponent<SpriteRenderer>().sortingOrder -= number;
        }

      
    }
}
