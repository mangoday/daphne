using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// 이 스크립트는 해피엔딩입니다.
// 아폴론과 다프네는 앞으로 뛰다가 어느시점(아르테미스존)에 도달하면
// 아폴론은 진행이 불가능하고 다프네는 아르테미스 옆으로가서 giggle.

public class HappyEnd : MonoBehaviour {
    public GameObject daphne, apolon;
    public float moveSpeed;
    bool isEnd = false;
    Animator anim;
    private void Start()
    {
        anim = daphne.transform.GetChild(0).GetComponent<Animator>();
    }
    // Use this for initializatio
    // Update is called once per frame
    
	// Use this for initializatio
	// Update is called once per frame
	void Update () {
        if (daphne.transform.position.z > -6.3) // daphne move
        {
            daphne.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            isEnd = true;
        }
        if (isEnd)
        {
            daphne.transform.rotation = Quaternion.Lerp(daphne.transform.rotation, Quaternion.Euler(new Vector3(0, -daphne.transform.rotation.y, 0)), 1f * Time.deltaTime);
            anim.SetBool("giggle", true);
        }
        if (apolon.transform.position.z > -3)
        {
            apolon.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene("Scene_Version3", LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
