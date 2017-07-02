using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 스크립트는 정해진 2차원 배열에 0,1,2,3 (통과, 큐브1, 큐브2, 큐브3)을 할당해 큐브를 생성하도록 합니다.
// - 필요한 것 -
//  - 2차원 배열, 행, 열
//  - 큐브종류 3
//  - random 값.
//  - 몇개의 큐브를 배치 할 것인지.

// -큐브생성-
//  - 큐브 한줄 생성후 일정시간 딜레이.
//  - 필요한 것 -
//  - 큐브 생성위치 ( 빈 오브젝트에서 출발 1개씩 생성한다 -> 포지션 값 변수 필요.)
//  - 위에서 만든 배열 값들.

public class CrerateRandomSeed : MonoBehaviour
{

    public int[,] map;
    public int row, col;
    public GameObject road;
    public GameObject[] cube;

    public int cubeNumber;
    public float waitTime;
    public float cubeSize;
    Transform createTrans;
    Vector3 plane;
    Vector3 createPos;
    public int count; // 막히는 부분이 있는지 확인.

    float lengtBetween;

	// Use this for initialization
	void Start () {
        count = 0;
        // lengtBetween = waitTime*GroundMove.flowSpeed/Time.deltaTime;
        Init();
        RandomSeed(map);

        // plane = GetComponentsInParent<Transform>()

        createTrans = GetComponentInParent<Transform>();
        StartCoroutine("CreateCube");

    }
    void Init()
    {
        float speed = GroundMove.flowSpeed/Time.deltaTime+1f;
        waitTime = cubeSize/speed;
        map = new int[col, row];
        createPos = transform.position;
    } // 초기화 필요한 친구들.

    // 인자로 받은 행렬에 값을 넣어 반환해준다.
    void RandomSeed(int[,] map)
    {
        for(int i=0; i < cubeNumber; i++) 
        {
            int temp = Random.Range(0, (row * col)-1); // 몇번 째 배열에 넣을 것인지 결정.
            map[temp / row, temp % row] = 1; // 정해진 배열에 몇번 째 큐브를 넣을것인지 결정.
        }
        
        for(int i=0; i< row; i++) // 첫줄은 비우자 + 마지막줄도 비우자.
        {
            map[0, i] = 0;
            map[col-1, i] = 0;
        }
        // 남은 곳은 0.
    }

    IEnumerator CreateCube() // 큐브 생성
    {
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                GameObject Cube;

                switch (map[i, j])
                {
                    case 0:
                        Cube = Instantiate(road);

                        iTween.FadeTo(Cube, 1.0f, 1.0f);

                        Cube.transform.parent = createTrans;
                        Cube.transform.position = createPos;
                        count = 0;
                        break;

                    case 1: // 전줄의 마지막이 1일경우 첫줄 혹은 두번째 줄을 로드로 해야함.
                        count++;
                        if (count == row) // 막힌 경우. road 생성.
                        {
                            Cube = Instantiate(road);
                            map[i + 1, j] = 0; // 다음 줄 1칸 확보해주기.
                            Cube.transform.position = createPos;
                        }
                        else
                        {
                            Cube = Instantiate(cube[Random.Range(0, cube.Length)]);
                            Cube.transform.position = createPos;
                        }

                        // 장애물의 대각선중 한곳을 비우자.
                        if (i < col-1 && j != 0  && j != row)
                        {
                            map[i + 1, Random.Range(j - 1, j + 1)] = 0;
                        }
                         iTween.FadeTo(Cube, 1.0f, 1.0f);
                        Cube.transform.parent = createTrans;
                        break;

                }
                
                createPos.x += -cubeSize; // 다음 큐브를 위한 X 포지션 교체
                // createPos.z = transform.position.z;
            }
            // 한줄 끝나면 한칸 올려줌 Z 포지션 교체, X 리셋
            count = 0;
            createPos.z += waitTime*GroundMove.flowSpeed/Time.deltaTime - cubeSize;

            // createPos.z += transform.position.z - cubeSize;

            // yield return null;
            yield return new WaitForSeconds(waitTime);
            // yield return new WaitForSeconds(GroundMove.flowSpeed/Time.deltaTime);
            createPos.x = 0;
        }
    }
}
