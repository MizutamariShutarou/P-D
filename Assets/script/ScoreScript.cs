using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private  static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        GetComponent<Text>().text = "Score:" + score.ToString();
    }

    // Update is called once per frame
    public void AddPoint(int point)
    {
        score = score + point;
        GetComponent<Text>().text = "Score:" + score.ToString();
    }
    public static int getpoint()
    {
        return score;
    }

}
