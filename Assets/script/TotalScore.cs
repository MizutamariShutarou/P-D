using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    public Text ScoreText;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        score = ScoreScript.getpoint();

        ScoreText.text = string.Format("Score:{0}", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
