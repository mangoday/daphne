using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//어떤 조작도 없으면 앞으로 전진한다.
//바닥큐브위에 올려져 있다. 
//충돌 처리를 한다면 
//부딪치는 오브젝트중 하나는 rigidbody를 가지고 있어야한다.
//그러므로 리지드 바디는 캐릭터가 가지고 있는다.

public class CharacterMove : MonoBehaviour {

	Rigidbody rb;
	
	public float speed = 2f;
	Vector3 mousePos;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
		// rb.velocity = speed * Vector3.up;
		
		// transform.Translate(speed * Vector3.forward);

		mousePos = Input.mousePosition;
		
		transform.position = mousePos;

		print(mousePos);
		
	}
}
