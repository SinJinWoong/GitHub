using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour {
    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetTrue()
    {
        animator.SetBool("IsMouse", true);
    }

    public void SetFalse()
    {
        animator.SetBool("IsMouse", false);
    }
}
