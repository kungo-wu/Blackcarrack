using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class starpuzzle : MonoBehaviour
{
    private string temporaryid;
    public string temporarycheck;
    private bool thistodo;
    [SerializeField]
    public UnityEvent tl_event;
    // Start is called before the first frame update
    void Start()
    {
        temporaryid=gameObject.name;
        GameEventSystem.instance.onItemTrigger+=starpuzzletemporary;
    }
    private void OnDisable() 
    {
        GameEventSystem.instance.onItemTrigger+=starpuzzletemporary;
    
    }

    // Update is called once per frame
   public void starpuzzletemporary(string _id)
    {
        if(temporaryid==_id&&!LoadScene.Scenecoming)
        {
            CallFader.instance.temporarychange=true;
            CallFader.instance.Scenechange="Telescope";
            thistodo=true;
            
            
        }

    }
    private void Update() 
    {
        if(CallFader.instance.temporaryupdate&&thistodo)
        {
             //tl_event.Invoke();
            
            //SceneManager.LoadScene("Telescope");
            //thistodo=false;
           // CallFader.instance.temporaryupdate=false;
             

        }
           
    }
}
