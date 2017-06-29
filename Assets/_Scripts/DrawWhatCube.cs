using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 이 스크립트는 GameManager의 List를 받아와 child의 이미지에게 몇번째 list가 들어가는지 그려줍니다.
// 한번 클릭 -> 첫번째 자식을 페이드 시키며 아래로 이동 -> 일정거리 이동후 5번째 자식으로 바꾸고 position 조정
// 첫번째 자식이 아래로 이동하는 동안 나머지 자식들은 왼쪽으로 이동.
// - Need
// - 마지막 자식의 위치.
// - 얼만큼 내려보낼 것인지.
// - scrollSpeed.
// - UIState : Draw, Scroll Frist Child, Scroll other Child.

public class DrawWhatCube : MonoBehaviour {
    public Sprite Image0, Image1;
    // Use this for initialization
    // Update is called once per frame
    Vector3 startPos;
    Vector3 fcPos;
    public float scrollSpeed;
    Transform tempT; // Global to Local을 위한 변수.
    public float fadeOutTime;

    private DrawWhatCube m_instance;
    public static DrawWhatCube instance;

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

    public enum UIState
    {
        draw,
        scrollFrist,
    }

    public UIState ui_state;

    void Start()
    {
        startPos = new Vector3(75, -100, 0);
        fcPos = new Vector3(75, -300, 0);
        ui_state = UIState.draw;
    }

    void Update()
    {
        if (OnClickCube.instance.m_State == OnClickCube.GameState.AddOneState) // 1회 클릭상태 일때.
        {
            ui_state = UIState.scrollFrist;
        }

        switch (ui_state)
        {
            case UIState.draw:
                Draw();
                break;
            case UIState.scrollFrist:
                ScrollFrist();
                break;
        }
        /*
        if(OnClickCube.instance.m_State == OnClickCube.GameState.Ready)
        {
            myRectTransform = GetComponent<RectTransform>();
            myRectTransform.localPosition = new Vector3(transform.localPosition.x + 350, transform.localPosition.y, transform.localPosition.z);
            transform.localPosition = myRectTransform.localPosition;
        }
        if(transform.localPosition.x > startPos.x)
        {
            myRectTransform.localPosition = new Vector3(myRectTransform.localPosition.x - scrollSpeed, myRectTransform.localPosition.y, myRectTransform.localPosition.z);
            transform.localPosition = myRectTransform.localPosition;
        }*/
    }

    void Draw()
    {
        if (OnClickCube.instance.m_State == OnClickCube.GameState.Click)
        {
            for (int i = 0; i < OnClickCube.instance.listSize; i++)
            {
                Transform child = transform.GetChild(i);
                if (OnClickCube.instance.m_List[i] == OnClickCube.CubeState.turnLeft)
                {
                    child.GetComponent<Image>().sprite = Image0;
                }
                else if (OnClickCube.instance.m_List[i] == OnClickCube.CubeState.turnRight)
                {
                    child.GetComponent<Image>().sprite = Image1;
                }
            }
        }
    }

    void ScrollFrist()
    {
        Transform child = transform.GetChild(0); // 첫 번째 자식.
        RectTransform myRectTransform;
        myRectTransform = child.GetComponent<RectTransform>();
        if (child.localPosition.y >=fcPos.y) // 목표지점 까지 이동
        {
            myRectTransform.localPosition = new Vector3(child.localPosition.x, child.localPosition.y - scrollSpeed, child.localPosition.z);
            child.localPosition = myRectTransform.localPosition;
            Image alpha = child.GetComponent<Image>(); // Fade out
            alpha.CrossFadeAlpha(0, fadeOutTime, true);

            
        }
        else // 상태 변화.
        {
            // 첫번째 자식을 5번째 image + x position 위치에 보내고 child 순서를 5번으로 바까준다 + alpha값 다시 회복
            child.transform.SetAsLastSibling();
            Transform child_Four = transform.GetChild(3); // 네 번째 자식.
            child.localPosition = new Vector3(child_Four.localPosition.x + 150, child_Four.localPosition.y, child_Four.localPosition.z);
            Image alpha = child.GetComponent<Image>(); // Fade in
            alpha.CrossFadeAlpha(1, 0, true);
            // 상태 변화.
            ui_state = UIState.draw;
        }
    }
}
