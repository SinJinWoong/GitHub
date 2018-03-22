using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public float radius;
    public Collider2D[] hitColliders;

    // Use this for initialization
    void Start () {
        radius = 1;
    }
	
	// Update is called once per frame
	void Update () {

    }

  public void next()
    {
        radius += 2; ;
         transform.localScale = new Vector3(radius, radius, 0);
       // ChangeState(transform.position, radius, TowerLight.lightState.black);
    }

    public void before()
    {

        radius -= 2;
        if (radius < 1)
        {
            radius = 1;
        }
        transform.localScale = new Vector3(radius, radius, 0);
        // ChangeState(transform.position, radius, TowerLight.lightState.black);
    }
}
