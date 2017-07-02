using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 이 스크립트는 바닥만 판별합니다.
// LeftCount, RightCount 를 쌓아서 최종 목적지 값을 저장하고 거기 까지 이동하도록 합니다.
public class CheckGround : MonoBehaviour {

    // Use this for initialization
    public int leftCount;
    public int rightCount;
    public Vector3 Destination;
    public CharacterMove cm;

    private void Start()
    {
        Destination.x = transform.parent.position.x;
    }
    private void Update()
    {
        Destination.y = transform.parent.position.y;
        Destination.z = transform.parent.position.z;
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.layer == LayerMask.NameToLayer("LeftCube")) // 왼쪽
        {
            leftCount++;
            Destination.x = Destination.x + 1.0f;
            iTween.MoveTo(transform.parent.gameObject, Destination, 2.0f);
            iTween.MoveTo(gameObject, Destination, 2.0f);
            
            //print("KK");
            //iTween.MoveTo(transform.parent.gameObject, transform.position + 1 * -Vector3.left, 0f);
            //iTween.MoveTo(gameObject, transform.position + 1 * -Vector3.left, 2.0f);
        }

        if (hit.gameObject.layer == LayerMask.NameToLayer("RightCube")) // 오른쪽
        {
            rightCount++;
            Destination.x = Destination.x - 1.0f;
            iTween.MoveTo(transform.parent.gameObject, Destination, 2.0f);
            iTween.MoveTo(gameObject, Destination, 2.0f);
            //iTween.MoveTo(transform.parent.gameObject, transform.position + 1 * -Vector3.right, 0f);
            //iTween.MoveTo(gameObject, transform.position + 1 * -Vector3.right, 2.0f);
        }
        //충돌한 물체가 방향 큐브이면
        //레이어를 1차 가르고
    }
    

}
