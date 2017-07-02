using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 이 스크립트는 다프네를 뒤에서 따라가는 아폴론의 태양의 역할을 합니다.
// 이 오브젝트를 지나쳐가는 물체들을 없애줍니다.
public class DestroyZone : MonoBehaviour {

    // 만약 지나쳐가는 물체가 길, 장애물 이라면 파괴.
    // 다프네라면 엔딩(나무로 변화)
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene("Scene_Endinging");
            // Ending Scene -> 다프네를 나무로바꿈. + 카메라줌.
        }

        //if(other.tag.Contains("벽"))
        //{
        //    Destroy(other.gameObject);
        //}
        Destroy(other.gameObject);
    }
}
