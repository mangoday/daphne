using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 이 스크립트는 길 왼쪽 배경을 만듭니다. 프리팹의 배열로 일정시간마다 3*8 큐브짜리 배경을 랜덤으로 만들어 줍니다.
// - need
// - Prefab Array
// - createDelay
// - Array size
// - createPos

//배열에 미리 종류 별로 오브젝트를 넣어둔다.
//최초 1회만 만들고 
// 종착지에 닿게 되면 다시 가져온다.
public class CreateLeftBG : MonoBehaviour {
    public GameObject[] BG;
    public float createDelay;
    public float currentTime;
    public int increaseZPos;
    public Transform createPos;




	// Use this for initialization
	void Start () {
        createPos = GetComponent<Transform>();
        createPos.position = transform.position;
        currentTime = createDelay;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if(currentTime > createDelay)
        {
            int temp = Random.Range(0, BG.Length);
            GameObject BGitem = Instantiate(BG[temp]);
            BGitem.transform.position = createPos.position;
            Vector3 temp2 = new Vector3(createPos.position.x, createPos.position.y , createPos.position.z - 6f);
            createPos.position = temp2;
            currentTime = 0;
        }
    }
}
