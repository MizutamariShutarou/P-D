using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;



public class Dropfail : MonoBehaviour
{
    [SerializeField] Sprite[] sp;
    float countdown = 4f;
    int count;

    public int ID1
    {
        get;
        set;
    }
    public int ID2
    { 
        get;
        set;
    }

    bool touchFlag;
    Vector2 m;
    RectTransform r, r2;

    public Vector2 P1
    {
        get;
        set;
    }
    public Vector2 P2
    {
        get;
        set;
    }
    Director d;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<RectTransform>();
        r2 = transform.parent.GetComponent<RectTransform>();
        d = GameObject.Find("D").GetComponent<Director>();
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown >= 0)
        {
            countdown -= Time.deltaTime;
            count = (int)countdown;
        }
        if (countdown <= 0)
        {
            if (touchFlag)
            {
                var pos = Vector2.zero;
                m = Input.mousePosition;
                RectTransformUtility.ScreenPointToLocalPointInRectangle
                    (r2, m, Camera.main, out pos);
                r.localPosition = pos;
                //SoundManager.Instance.Play("操作音");
            }


            if (P1.x == 0)
            {
                P1 = GetComponent<RectTransform>().position;
                P2 = RectTransformUtility.WorldToScreenPoint(Camera.main, P1);
            }
            else
            {
                if (!touchFlag)
                {
                    GetComponent<RectTransform>().position = P1;

                }
            }
        }
    }
    public void Set(int n)
    {
        //if (countdown <= 0)
        //{
            GetComponent<SpriteRenderer>().sprite = sp[n];
        //}
    }
    public void GetDrop()
    {
        if(countdown <= 0)
        {
            touchFlag = true; 
        }
        
    }
    public void SetDrop()
    {
        if (countdown <= 0)
        {
            touchFlag = false;
            Delete();
        }
        //Delete();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(touchFlag)
        {
            if(d.CheckPos(m,collision.gameObject.GetComponent<Dropfail>().P2))
            {
                d.ChangePos(gameObject, collision.gameObject);
            }
        }
    }
    private async void Delete()
    {
        while (true)
        {
            d.DeleteDrop();
            if (d.Check()) break;
            await Task.Delay(400);
            d.DownDrop();
            await Task.Delay(250);
            d.ResetDrop();
            await Task.Delay(250);
        }
    }

}
