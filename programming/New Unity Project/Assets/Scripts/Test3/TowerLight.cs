using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLight : MonoBehaviour {

    public enum lightState
    {
        building = 0,// 가장 밝음
        gray_0 = 1, // 가장 밝음
        gray_25, // 조금 어두움
        gray_50, //중간
        gray_75, // 검은색보다 밝음
        black // 가장 어두움
    }

    public lightState curState = lightState.black;

    void Start () {
        gameObject.transform.GetComponent<SpriteRenderer>().color = Color.white;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //  Debug.Log("!!!!!!!!!!!!!!!!!");
            gameObject.transform.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            gameObject.transform.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

}
