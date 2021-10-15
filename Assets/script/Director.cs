using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    
    // Score Script用　//
    public GameObject scoreGUI;
    public static int point = 50;
    //public static int = score;
    GameObject[,] o = new GameObject[5, 6];
    public GameObject[,] Obj
    {
        get { return o; }
        set { o = value; }
    }

    int[,] f = new int[5, 6];

    public int[,] Field
    {
        get { return f; }
        set { f = value; }
    }

   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool CheckPos(Vector2 p1,Vector2 p2)
    {
        float x = p1.x - p2.x;
        float y = p1.y - p2.y;
        float r = Mathf.Sqrt(x * x + y * y);
        if(r < 93.75f)
        {
            SoundManager.Instance.Play("操作音");//入れ替わり時に効果音
            return true;
        }
        return false;
    }
    public void ChangePos(GameObject obj1,GameObject obj2)
    {
        Dropfail d1 = obj1.GetComponent<Dropfail>();
        Dropfail d2 = obj2.GetComponent<Dropfail>();
        GameObject tempObj;
        Vector2 tempPos;
        int temp;
        tempObj = Obj[d1.ID1, d1.ID2];
        Obj[d1.ID1, d1.ID2] = Obj[d2.ID1, d2.ID2];
        Obj[d2.ID1, d2.ID2] = tempObj;

        temp = Field [d1.ID1, d1.ID2];
        Field[d1.ID1, d1.ID2] = Field[d2.ID1, d2.ID2];
        Field[d2.ID1, d2.ID2] = temp;

        tempPos = d1.P1;
        d1.P1 = d2.P1;
        d2.P1 = tempPos;

        tempPos = d1.P2;
        d1.P2 = d2.P2;
        d2.P2 = tempPos;

        temp = d1.ID1;
        d1.ID1 = d2.ID1;
        d2.ID1 = temp;

        temp = d1.ID2;
        d1.ID2 = d2.ID2;
        d2.ID2 = temp;

    }
    public void DeleteDrop()

    {
        
        int c = 0, t = 0;
        int[,] temp = new int[5, 6];
        int[,] temp2 = new int[5, 6];

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (j == 0)
                {
                    c = 1;
                    t = Field[i, j];
                    continue;
                }
                if (t == Field[i, j])
                {
                    c++;
                    if (c>= 3)//c＝3、4、5、…の時を追加
                    {
                        temp[i, j] = c;
                        // ScoreScript用(横) //
                        scoreGUI.SendMessage("AddPoint", point * c);
                        SoundManager.Instance.Play("ドロップが消えた時");
                    }
                    //追加//
                    //if (c == 4)//c＝3、4、5、…の時を追加
                    //{
                    //    temp[i, j] = c;
                    //    // ScoreScript用(横) //
                    //    scoreGUI.SendMessage("AddPoint", point * c - 310);
                    //    SoundManager.Instance.Play("ドロップが消えた時");
                    //}
                    //if (c == 5)//c＝3、4、5、…の時を追加
                    //{
                    //    temp[i, j] = c;
                    //    // ScoreScript用(横) //
                    //    scoreGUI.SendMessage("AddPoint", point * c + 35);
                    //    SoundManager.Instance.Play("ドロップが消えた時");
                    //}
                    //if (c == 6)//c＝3、4、5、…の時を追加
                    //{
                    //    temp[i, j] = c;
                    //    // ScoreScript用(横) //
                    //    scoreGUI.SendMessage("AddPoint", point * c - 175);
                    //    SoundManager.Instance.Play("ドロップが消えた時");
                    //}
                    //if (c == 3 && c == 3)//c＝3、4、5、…の時を追加
                    //{
                    //    temp[i, j] = c;
                    //    // ScoreScript用(横) //
                    //    scoreGUI.SendMessage("AddPoint", point * c * 1.5);
                    //    SoundManager.Instance.Play("ドロップが消えた時");
                    //}
                }
                else
                {
                    c = 1;
                    t = Field[i, j];
                }
            }
            
        }
        for (int j = 0; j < 6; j++)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    c = 1;
                    t = Field[i, j];
                    continue;
                }
                if (t == Field[i, j])
                {
                    c++;          //t//
                    if (c >= 3)//&& c < 5)
                    {             //t//
                        temp2[i, j] = c;
                        // ScoreScript用（縦） //
                        scoreGUI.SendMessage("AddPoint", point * c);
                        SoundManager.Instance.Play("ドロップが消えた時");
                    }                //t//
                    //else if (6 >= c && c < 9)
                    //{                //t//
                    //    temp[i, j] = c;
                    //    // ScoreScript用（縦） //               //t/////
                    //    scoreGUI.SendMessage("AddPoint", point * c * 1.2);//6個同時けしでスコアボーナス
                    //                                            //t/////
                    //    SoundManager.Instance.Play("ドロップが消えた時");
                    //}
                    //else if (9 >= c && c < 12)
                    //{
                    //    temp[i, j] = c;
                    //    // ScoreScript用（縦） //
                    //    scoreGUI.SendMessage("AddPoint", point * c * 1.3);//9個同時けしでスコアボーナス
                    //    SoundManager.Instance.Play("ドロップが消えた時");
                    //}
                    //else if (12 >= c && c < 15)
                    //{
                    //    temp[i, j] = c;
                    //    // ScoreScript用（縦） //
                    //    scoreGUI.SendMessage("AddPoint", point * c * 1.4);//9個同時けしでスコアボーナス
                    //    SoundManager.Instance.Play("ドロップが消えた時");
                    //}
                    //else if (15 >= c && c < 30)
                    //{
                    //    temp[i, j] = c;
                    //    // ScoreScript用（縦） //
                    //    scoreGUI.SendMessage("AddPoint", point * c * 1.5);//9個同時けしでスコアボーナス
                    //    SoundManager.Instance.Play("ドロップが消えた時");
                    //}
                }
                else
                {
                    c = 1;
                    t = Field[i, j];
                }
            }

        }
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                if(temp[i,j] >= 3)
                {
                    for(int k = j; temp[i,j] > 0; k--, temp[i,j]--)
                    {
                        Field[i, k] = 6;
                        Obj[i, k].GetComponent<Dropfail>().Set(6);
                    }
                }
                if(temp2[i,j] >= 3)
                {
                    for(int k = i; temp2[i,j] > 0; k--, temp2[i,j]--)
                    {
                        Field[k, j] = 6;
                        Obj[k, j].GetComponent<Dropfail>().Set(6);
                    }
                }
            }
        }

    }
    public void DownDrop()
    {
          
        for(int j = 0; j < 6; j++)
        {
            for(int i = 1; i < 5; i++)
            {
                if(Field[i,j] == 6)
                {
                    for(int k = i; k > 0; k--)
                    {
                        if(Field[k - 1,j] != 6)
                        {
                            ChangePos(Obj[k, j], Obj[k - 1, j]);
                        }

                    }
                }
            }
        }
    }
    public void ResetDrop()
    {
       

        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j <  6; j++)
            {
                if(Field[i,j] == 6)
                {
                    int type = Random.Range(0, 6);
                    Field[i, j] = type;
                    Obj[i, j].GetComponent<Dropfail>().Set(type);
                }
            }
        }
    }
    public bool Check()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if(Field[i,j] == 6)
                {
                    return false;
                }
            }
        }
        return true;
    }

    //public static int getpoint()
    //{
    //    return score;
    //}

}
