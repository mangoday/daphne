using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 스크립트는 현재(다음번 클릭에 놓여질) 블럭상태(방향, Something)을 판별해
// 플레이어가 Road 를 클릭할 경우 그 자리에 어떤 Object를 배치하는 스크립트 입니다.
// - 현재 상태 변수(대기, 클릭, 추가)
// - 리스트(어떤 종류의 큐브인지) 몇 개? & 몇 종?
// - 1클릭 성공시 리스트의 맨앞 상태를 판별해 오브젝트를 배치한 후 다음 1개의 블럭을 리스트에 추가

public class OnClickCube : MonoBehaviour {
    private OnClickCube m_instance;
    public static OnClickCube instance;

    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
            instance = m_instance;
        }
        else
        {
            Destroy(this); // 게임매니저가 두개가되면 안되니 하나는 지우자.
        }
    }

    public enum GameState
    {
        Ready,
        Click,
        AddOneState,
    }
    
    public enum CubeState
    {
        turnLeft,
        turnRight,
        // 기타 추가사항.
    }

    GameState m_State; // 현재 게임 상태
    public List<CubeState> m_List; // 블럭 리스트
    public int listSize; // 총 몇개
    public int cubeSize; // 몇개의 종류
    public GameObject Cube0, Cube1;

    // Use this for initialization
    void Start () {
        m_State = GameState.Ready;
        // 나중에 지울것
        listSize = 4;
        cubeSize = 2;
        // 나중에 지울것 
    }

    void InitList() // list 초기화.
    {
        m_List = new List<CubeState>();
        while(m_List.Count < listSize)
        {             
            m_List.Add((CubeState)Random.Range(0, cubeSize));
        }
    }

    void PrintList()
    {
        for (int i= 0; i < listSize; i++)
        {
            Debug.Log((CubeState)m_List[i]);
        }
    }
    
	
	// Update is called once per frame
	void Update () {
	    switch(m_State)
        {
            case GameState.Ready:
                Ready();
                break;
            case GameState.Click:
                Click();
                break;
            case GameState.AddOneState:
                AddOne();
                break;
        }	
	}

    // List 준비.
    public void Ready()
    {
        InitList();
        PrintList();
        m_State = GameState.Click;
    }

    // 클릭가능한 상태. 레이를 쏴서 큐브를 배치할 수 있는 블럭이라면 리스트의 맨앞 오브젝트를 배치하고 Add로 넘김 
    public void Click()
    {
        if (Input.GetMouseButtonDown(0)) // 왼쪽 클릭
        {
            RaycastHit hit = new RaycastHit(); // hit정보
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // mouse Ray

            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                if (hit.transform.tag == "Road") // tag가 배치가능이면
                {
                    Transform target = hit.transform;
                    if (m_List.Count > 0)
                    {
                        GameObject ChangeObject;
                        if(m_List[0] == CubeState.turnLeft) // 왼쪽회전 큐브 생성
                        {
                            ChangeObject = Instantiate(Cube0);
                            Destroy(target.gameObject); // 삭제 후 
                            ChangeObject.transform.position = target.position; // 배치
                            m_List.RemoveAt(0); // 첫번째 경우 삭제
                            m_State = GameState.AddOneState; // state 변경
                            return;
                        }
                        else if(m_List[0] == CubeState.turnRight) // 오른쪽회전 큐브 생성
                        {
                            ChangeObject = Instantiate(Cube1);
                            Destroy(target.gameObject); // 삭제 후 
                            ChangeObject.transform.position = target.position; // 배치
                            m_List.RemoveAt(0); // 첫번째 경우 삭제
                            m_State = GameState.AddOneState; // state 변경
                        }
                        else
                        {
                            print("help me");
                        }
                    }
                }
             }  
        }
    }

    // 1개의 List item을 추가하고 Click으로 보냄.
    public void AddOne()
    {
        m_List.Add((CubeState)Random.Range(0, cubeSize)); // 한개아이템 추가.
        m_State = GameState.Click;
    }
}
