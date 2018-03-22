using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTest2 : MonoBehaviour {


    public LightTest_2_1.lightState light;
    public Collider2D[] hitColliders;

    void Awake()
    {

    }

    void OnTriggerEnter2D (Collider2D col) // 타일을 클릭하면 타일위에 건물이 생겼다고 가정함
    {
        if (col.tag != "light" && col.transform.GetComponent<LightTest_2_1>().curState > light)
        {
            col.transform.GetComponent<LightTest_2_1>().curState = light;
        }
    }
}
