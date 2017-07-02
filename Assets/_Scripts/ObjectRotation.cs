using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour {

	//회전 방향을 위한 변수
	//

	// Use this for initialization
	void Start () {
		
		iTween.RotateBy(gameObject, iTween.Hash("y", .25, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .4));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
