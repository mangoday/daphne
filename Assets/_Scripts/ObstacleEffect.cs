using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		//조건문으로 인터렉션
		
		CharacterMove.Instance.moveSwitch = false;
	}

}
