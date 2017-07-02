using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlArtemis : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("giggle", true);
	}
}
