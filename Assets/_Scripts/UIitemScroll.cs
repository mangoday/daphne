using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 이 스크립트는 자신이 부모의 몇번째 자식인지 알아낸 다음
// 첫번째 자식이면 지정된 위치까지 이동.
// 나머지 자식들은 자기 앞의 자식의 위치.x + 150의 위치로 이동한다.

public class UIitemScroll : MonoBehaviour {
    Transform parent;
    Transform forwardChild;

    public int count; // 몇번째 자식이냐.
    Vector3 startPos;
    public float scrollSpeed;
    RectTransform myRect;
    
	// Use this for initialization
	void Start () {
        startPos = new Vector3(-475, -100, 0);
        parent = transform.parent;
        myRect = transform.GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
    // 만약 첫 번째 자식이면 지정된 위치로 이동, 나머지는 자기 위의 자식의 localposition.x + 150의 위치로 이동합니다.
	void Update () {
        if(DrawWhatCube.instance.ui_state == DrawWhatCube.UIState.draw)
        {
            for(int i=0; i < 5; i++)
            {
                if(parent.GetChild(i).name == transform.name)
                {
                    count = i; // 몇번째 자식인지.
                    if (i != 0)
                    {
                        forwardChild = parent.GetChild(i - 1); // 내 앞 친구.
                    }
                }
            }
        }
        if (myRect.localPosition.x >= startPos.x && count == 0) // 맨 앞친구.
        {
            myRect.localPosition = new Vector3(myRect.localPosition.x - scrollSpeed, myRect.localPosition.y, myRect.localPosition.z);
            transform.localPosition = myRect.localPosition;
        }
        else if(count != 0)// 나머지 친구.
        {
            if (myRect.localPosition.x >= forwardChild.localPosition.x + 150) // 일정거리를 두고 거기까지 이동.
            {
                myRect.localPosition = new Vector3(myRect.localPosition.x - scrollSpeed, myRect.localPosition.y, myRect.localPosition.z);
                transform.localPosition = myRect.localPosition;
            }
        }
	}
}
