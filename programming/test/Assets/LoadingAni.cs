using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingAni : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Invoke("LoadingUIEnd", 2);
    }
    void LoadingUIEnd()
    {
        gameObject.SetActive(false);
    }
}
