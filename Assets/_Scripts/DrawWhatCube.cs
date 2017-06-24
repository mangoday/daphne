using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 이 스크립트는 GameManager의 List를 받아와 child의 이미지에게 몇번째 list가 들어가는지 그려줍니다.

public class DrawWhatCube : MonoBehaviour {
    public Sprite Image0, Image1;
    // Use this for initialization
    // Update is called once per frame
        
    
    void Update()
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
