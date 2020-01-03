using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ask : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //开始游戏
    public void BeingingGame()
    {
        //加载场景
        //Application.LoadLevel("MainScene");
        SceneManager.LoadScene("Ask");
        print("Ask界面已打印出来");
    }
}
