using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    static public UIManager instance;

    public GameObject SelectButton;
    public Image image;

    // Use this for initialization
    void Start () {
        image = transform.GetChild(0).GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SeletMe()
    {
    }
}
