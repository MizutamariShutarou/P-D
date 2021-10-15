using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class GoGame : MonoBehaviour
{
    //public bool DontDestroyEnabled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene()
    {
        //DontDestroyEnabled = false;
        SceneManager.LoadScene("Scenes/SampleScene");
       
    }
}
