using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 스크립트는 마우스가 클릭을 할 시 나오는 Ray를 바탕으로
// User가 선택한 큐브를 어떤 종류로 바꾸도록 하는 스크립트입니다.
// - Need - 
// - Ray
// - 선택한 위치에 Prefab(Button click을 통해서 선택됌)을 하나 놓는다.

public class ClickCube : MonoBehaviour {
    // Use this for initialization
    public GameObject LeftCube, RightCube, UpCube, DownCube; // 방향 큐브설정
    GameObject NowCube; // 지금 생성돼는 큐브
    OnArrowButtonClickDown oabcd; // flag 가져오는.
	void Start () {
        oabcd = GetComponent<OnArrowButtonClickDown>();
    }
	
	// Update is called once per frame
	void Update () {

        switch(oabcd.nowDirection) // 지금생설됄 큐브를 상황에 맞게 변경시킵니다.
        {
            case OnArrowButtonClickDown.DirectionState.Null:
                return;
                break;
            case OnArrowButtonClickDown.DirectionState.Left:
                NowCube = LeftCube;
                break;
            case OnArrowButtonClickDown.DirectionState.Right:
                NowCube = RightCube;
                break;
            case OnArrowButtonClickDown.DirectionState.Up:
                NowCube = UpCube;
                break;
            case OnArrowButtonClickDown.DirectionState.Down:
                NowCube = DownCube;
                break;
        }

        if (Input.GetMouseButtonDown(0)) // 왼쪽 클릭
        {
            RaycastHit hit = new RaycastHit(); // hit정보
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // mouse Ray
            
            if(Physics.Raycast(ray.origin, ray.direction, out hit))
            {
               if(hit.transform.tag == "Road") // tag가 큐브면
               {
                    Transform target = hit.transform;
                    GameObject ChangeObject = Instantiate(NowCube);
                    Destroy(target.gameObject); // 삭제 후 
                    ChangeObject.transform.position = target.position;
               }
            }
        }
	}
}
