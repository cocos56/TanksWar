using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int coinscore = 0;
    Text textObj;
    void Start()
    {
       
        //GameObject.Find("Canvas/score1").GetComponent<Text>().text = " " + coinscore;
        textObj = GameObject.Find("Canvas/Text").GetComponent<Text>();
        textObj.text = " " + coinscore;
    }


    void Update()
    {
        GameObject.Find("Canvas/Text").GetComponent<Text>().text = " " + coinscore;
        if(coinscore>=23000)
        SceneManager.LoadScene("Victory");

    }
    public void Add5()
    {
        coinscore = coinscore + 500;
    }
    public void Add1()
    {
        coinscore = coinscore + 100;
    }
    public void Add9()
    {
        coinscore = coinscore + 900;
    }
    public void Minus()
    {
        coinscore = coinscore - 1000;
    }
}