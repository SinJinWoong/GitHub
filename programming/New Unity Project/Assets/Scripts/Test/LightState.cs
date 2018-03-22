using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LightState : MonoBehaviour {
    
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
    public float radius;
    public Collider2D[] hitColliders;

    void Start () {

    }

    void Update()
    {


        //밝기 상태 확인 
        switch (curState)
        {
            case lightState.building:
                gameObject.transform.GetComponent<SpriteRenderer>().color = Color.red;
                radius = 0.7f;
                ChangeState(transform.position, radius, lightState.gray_0);
                break;
            case lightState.gray_0: // 숫자가 255에 가까울수록 밝음
                gameObject.transform.GetComponent<SpriteRenderer>().color = Color.white;
                radius = 0.2f;
                ChangeState(transform.position, radius, lightState.gray_25);
                break;
            case lightState.gray_25:
                gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(191.25f / 255f, 191.25f / 255f, 191.25f / 255f);
                radius = 0.2f;
                ChangeState(transform.position, radius, lightState.gray_50);
                break;
            case lightState.gray_50:
                gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(127.5f / 255f, 127.5f / 255f, 127.5f / 255f);
                radius = 0.2f;
                ChangeState(transform.position, radius, lightState.gray_75);
                break;
            case lightState.gray_75:
                gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(63.75f / 255f, 63.75f / 255f, 63.75f / 255f);
                radius = 0.2f;
                ChangeState(transform.position, radius, lightState.black);
                break;
            case lightState.black:
                gameObject.transform.GetComponent<SpriteRenderer>().color = Color.black;
                radius = 0.2f;
                break;
        }

    }

    public void ChangeState(Vector2 center, float radius, lightState lig)
    {
        hitColliders = Physics2D.OverlapCircleAll(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject != this.gameObject && hitColliders[i].transform.GetComponent<LightState>().curState > this.curState)
            {
            hitColliders[i].transform.GetComponent<LightState>().curState = lig;
            }
            i++;
        }
    }

    void OnMouseDown() // 타일을 클릭하면 타일위에 건물이 생겼다고 가정함
    {
        curState = lightState.building;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
