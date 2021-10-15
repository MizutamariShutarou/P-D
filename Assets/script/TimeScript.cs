using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class TimeScript : MonoBehaviour
{

    //カウントダウン
    public float time = 60.0f;
    //public Text timerText;
    public Text CountText;
    int retime;
    float countdown = 4f;
    int count;
    //public bool isTimeUp;
    
    //時間を表示するText型の変数
    public Text timeText;

    // Update is called once per frame
    private void Start()
    {
        //isTimeUp = false;
    }
    void Update()
    {
        if(countdown >= 0)
        {
            countdown -= Time.deltaTime;
            count = (int)countdown;
            CountText.text = count.ToString();
        }
        else if(countdown <= 0)
        {
            CountText.text = "GO!";
            time -= Time.deltaTime;
            retime = (int)time;
            timeText.text = retime.ToString() + "秒";
            if(retime == 0)
            {
                SceneManager.LoadScene("Scenes/GameOver");
            }
        }
        //else if(countdown < 0)
        //{
        //    CountText.text = "";
        //}
        



        //if (0 < time)
        //{
        //    //時間をカウントダウンする
        //    time -= Time.deltaTime;
            
        //    //時間を表示する
        //    timeText.text = time.ToString("f1") + "秒";

        //}



        
        //else if (time <= 0)
        //{
        //    //isTimeUp = true;

        //    //timeText.text = "Game Over";
        //    SceneManager.LoadScene("Scenes/GameOver");
        //}

    }
}