using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoveObject : MonoBehaviour
{

    float depth = 10.0f;
    float speed = 1.5f;

    void Start()
    {
    }

    void Update()
    {
        var mousePos = Input.mousePosition;
        var wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, depth));
        // transform.position = Vector3.MoveTowards(transform.position, wantedPos, speed * Time.deltaTime);
        transform.position = wantedPos;
    }
}