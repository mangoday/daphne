using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndingManager : MonoBehaviour {
    public GameObject Player;
    public GameObject tree;
    public Camera camera;
    public float waitTime;
    bool isEnd;
    // Update is called once per frame
    private void Start()
    {
        StartCoroutine("CamCtrl");
    }

    IEnumerator CamCtrl()
    {
        while (camera.orthographicSize >= 2)
        {
            camera.orthographicSize -= 1;
            yield return new WaitForSeconds(waitTime);
        }
        GameObject dapTree = Instantiate(tree);
        dapTree.transform.position = Player.transform.position;
        Destroy(Player.gameObject);
        isEnd = false;
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
