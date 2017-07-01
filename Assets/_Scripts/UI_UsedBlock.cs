using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_UsedBlock : MonoBehaviour {
    public Text text;
    public int count;
	// Use this for initialization
	void Start () {
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(OnClickCube.instance.m_State == OnClickCube.GameState.AddOneState)
        {
            count++;
        }
        text.text = "Use Block : " + count.ToString();
    }
}
