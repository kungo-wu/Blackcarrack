using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
    public string backscene;
     private bool thistodo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)&&CallFader.instance.temporarychange==false)
        {
          CallFader.instance.temporarychange=true;
          thistodo=true;

        }
        if(CallFader.instance.temporaryupdate&&thistodo)
        {
             //tl_event.Invoke();
             CallFader.instance.temporaryupdate=false;
             SceneManager.LoadScene(backscene);
             thistodo=false;
             

        }
    }

    
}
