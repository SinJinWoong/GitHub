using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTest_2_1 : MonoBehaviour {
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

void Awake () {
        curState = lightState.black;
        if(curState == lightState.black)
        {
            gameObject.transform.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }

    void OnTriggerEnter2D(Collider2D col) // 타일을 클릭하면 타일위에 건물이 생겼다고 가정함
    {
        //밝기 상태 확인 
        switch (curState)
        {
            case lightState.gray_0: // 숫자가 255에 가까울수록 밝음
                gameObject.transform.GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case lightState.gray_25:
                gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(191.25f / 255f, 191.25f / 255f, 191.25f / 255f);
                break;
            case lightState.gray_50:
                gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(127.5f / 255f, 127.5f / 255f, 127.5f / 255f);
                break;
            case lightState.gray_75:
                gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(63.75f / 255f, 63.75f / 255f, 63.75f / 255f);
                break;
            case lightState.black:
                gameObject.transform.GetComponent<SpriteRenderer>().color = Color.black;
                break;
        }
    }
}
