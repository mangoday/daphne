using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{


    Vector3 direction;
    public float moveSpeed;

    // Use this for initialization
    void Start()
    {
        direction = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
		if(transform.position.z<10)
		{
        transform.Translate(direction * moveSpeed * Time.deltaTime);

		}

    }
}
