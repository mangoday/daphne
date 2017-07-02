using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFadeIn : MonoBehaviour {

	Renderer rd;

	// Use this for initialization
	void Start () {

		rd = GetComponent<Renderer>();
		
		// rd.ren

		iTween.FadeTo(gameObject, 1.0f, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
