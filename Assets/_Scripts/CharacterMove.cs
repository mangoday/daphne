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




//캐릭터는 물위를 떠다닌다.
//


[RequireComponent(typeof(CharacterController))]
public class CharacterMove : MonoBehaviour
{


    CharacterController charCtrl;


    public float speed;
    Vector3 mousePos;

    public bool moveSwitch = true;
    public Vector3 moveDirection = Vector3.forward;

    //싱글톤 구조
    public static CharacterMove Instance = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }




    // Use this for initialization
    void Start()
    {

        charCtrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (moveSwitch)
        {
            transform.Translate(speed * moveDirection);
        }


        //보통 블럭을 밟으면 전부 파괴

        //-z방향으로 이동.
        charCtrl.SimpleMove(-Vector3.forward * speed);





    }


    //충돌 처리
    //장애물과 만나면 한칸 튕긴다.
    //1. 돌과 같은 장애물에 충돌되면
    //2. 충돌체가 장애물이면
    //3. 캐릭터는 한칸 튕긴다.
    // private void OnTriggerEnter(Collider other)
    // {
    //     //충돌한 물체가 장애물이면
    //     if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
    //     {
    //         //캐릭터는 한칸 뒤로 간다.
    //         transform.Translate(Vector3.forward);
    //     }
    // }

    /// <summary>
    /// OnControllerColliderHit is called when the controller hits a
    /// collider while performing a Move.
    /// </summary>
    /// <param name="hit">The ControllerColliderHit data associated with this collision.</param>
    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        //충돌한 물체가 장애물이면
        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            print(hit);

            //자연스럽게 움직이도록
            //캐릭터는 한칸 뒤로 간다.

            // StartCoroutine(MoveBackWard());
            float backValue = 1.0f;

            iTween.MoveTo(gameObject, transform.position + 2*Vector3.forward , 2.0f);


            
        }

        //충돌한 물체가 방향 큐브이면
        //레이어를 1차 가르고
        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            //오른쪽 방향 블럭일 때와
            if(true)
            {
                
            }
            //왼쪽 방향 블럭일 때로 거른다.
            else
            {

            }
        }


    }

    // IEnumerator MoveBackWard()
    // {
    //     transform.Translate(-Vector3.forward);

    //     yield return Wai
    // }



}
