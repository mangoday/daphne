using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 스크립트는 다프네를 뒤에서 따라가는 아폴론의 태양의 역할을 합니다.
// 이 오브젝트를 지나쳐가는 물체들을 없애줍니다.
public class DestroyZone : MonoBehaviour {

    // 만약 지나쳐가는 물체가 길, 장애물 이라면 파괴(아래로 이동시킨 후 일정 높이 가면 없어지도록)
    // 다프네라면 엔딩(나무로 변화)
    public float downSpeed;
    public float destroyHeight;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Contains("Road") || other.tag.Contains("Cube"))
        {
            Vector3 cubePos;
            cubePos = other.transform.position;
            while (other.transform.position.y > destroyHeight)
            {
                cubePos.y -= downSpeed;
                other.transform.position = cubePos;
            }
            Destroy(other.gameObject);
        }
    }
}
