using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//어떤 조작도 없으면 앞으로 전진한다.
//바닥큐브위에 올려져 있다. 
//충돌 처리를 한다면 
//부딪치는 오브젝트중 하나는 rigidbody를 가지고 있어야한다.
//그러므로 리지드 바디는 캐릭터가 가지고 있는다.


//보도블럭을 특정 블럭위에서만 간다.
//기본 디폴트는 파괴시킨다 캐릭터를

public class CharacterMove : MonoBehaviour {


	CharacterController cc;
	public float gravityValue = -1;
	
	public float speed = 2f;
	Vector3 mousePos;

	public bool moveSwitch = true;
	public Vector3 moveDirection = Vector3.forward;

	//싱글톤 구조
	public static CharacterMove Instance = null;
	private void Awake()
	{
			if(Instance == null)
			{
				Instance = this;
			}
	}




	// Use this for initialization
	void Start () {
		//캐릭터 시작값 정할것.
		// transform.position = 

		cc = GetComponent<CharacterController>();

		
	}
	
	// Update is called once per frame
	void Update () {
		//중력. 땅에 붙어 있게만든다. = > 필요없다.
		//변할일이 없음.

		if(moveSwitch)
		{
		// transform.Translate(speed * moveDirection);
		//캐릭터 컨트롤러에 중력이 붙어있다.
		cc.SimpleMove(speed*moveDirection);
		}
		

		//보통 블럭을 밟으면 전부 파괴




		// mousePos = Input.mousePosition;
		
		// transform.position = mousePos;

		// print(mousePos);
		
	}

	/// <summary>
	/// OnControllerColliderHit is called when the controller hits a
	/// collider while performing a Move.
	/// </summary>
	/// <param name="hit">The ControllerColliderHit data associated with this collision.</param>
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		//장애물이랑 부딪치면
		if(hit.gameObject.tag == "Cube")
		{
			moveDirection = Vector3.right;
			// speed = 5;
		}
		
	}

}
