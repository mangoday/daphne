using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneCharacterMove : MonoBehaviour {

public float scrollSpeed = 0.5F;
    public Renderer rend;



	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		Vector3 destination = transform.position +8*Vector3.down;
		
		iTween.MoveTo(gameObject, iTween.Hash("position", destination, "time", 5f) );
		StartCoroutine(OffsetMove());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator OffsetMove()
	{
		float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(offset, 0);
		yield return null;
	}
}
