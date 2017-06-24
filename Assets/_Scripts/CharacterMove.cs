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
    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        print(hit.collider.gameObject.layer);
        //충돌한 물체가 장애물이면
        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            print(hit);
            //캐릭터는 한칸 뒤로 간다.
            transform.Translate(-Vector3.forward);
        }
    }



}
