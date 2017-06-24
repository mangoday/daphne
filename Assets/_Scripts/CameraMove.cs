using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 스크립트는 메인 카메라의 이동을 담당합니다.
// 메인카메라는 우선은 앞으로 계속 움직입니다.
//  - 필요한 것 -
//  - moveSpeed
//  - moveDirection
public class CameraMove : MonoBehaviour {

    Vector3 direction;
    public float moveSpeed;
    public GameObject Target;
	// Use this for initialization
	void Start () {
                
        // direction =  Target.transform.up - transform.forward;
        direction =  -Vector3.forward;

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
	}
}
