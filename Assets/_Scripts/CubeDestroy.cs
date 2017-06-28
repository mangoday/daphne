using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 이 오브젝트는 디스트로이존을 지나면 신호를 받아. 큐브를 아래로 움직이고 일정거리이상 내려가면 
// 제거하도록 하는 스크립트입니다.
// - Need -
// - Flag
// - downSpeed
// - destroyHeight
public class CubeDestroy : MonoBehaviour {

    public bool isExiting;
    public float downSpeed;
    public float destroyheight;
	// Use this for initialization
	void Start () {
        isExiting = false;
        destroyheight = -4f;
        downSpeed = 1f; 	
	}
	
	// Update is called once per frame
	void Update () {
        if(isExiting)
        {
            print("KKK");
            if(transform.position.y > destroyheight)
            {
                transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }	
	}
}
