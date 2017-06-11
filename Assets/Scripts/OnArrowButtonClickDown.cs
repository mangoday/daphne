using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 이 스크립트는 UI 버튼을 누를때 User가 놓고 싶은 타일의 flag로 변경시켜줍니다. 이 flag로 ClickCube에서 생성할 타일을 결정하게해 줍니다.

public class OnArrowButtonClickDown : MonoBehaviour {

    public enum DirectionState
    {
        Null,
        Left,
        Right,
        Up,
        Down
    }
    public DirectionState nowDirection;
	// Use this for initialization
	void Start () {
        nowDirection = DirectionState.Null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClickLeft()
    {
        nowDirection = DirectionState.Left;
    }
    public void OnClickRight()
    {
        nowDirection = DirectionState.Right;
    }
    public void OnClickUp()
    {
        nowDirection = DirectionState.Up;
    }
    public void OnClickDown()
    {
        nowDirection = DirectionState.Down;
    }
}
