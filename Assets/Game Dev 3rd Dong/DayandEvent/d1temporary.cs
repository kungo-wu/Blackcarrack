using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class d1temporary : MonoBehaviour
{
    private string temporaryid;
    public string dayTarget;
    private bool thistodo;
    // Start is called before the first frame update
    void Start()
    {
        temporaryid=gameObject.name;
        GameEventSystem.instance.onItemTrigger+=d1;

    }

    private void OnDisable() 
    {
        GameEventSystem.instance.onItemTrigger+=d1;
    
    }
    // Update is called once per frame
    void Update()
    {
      
           
    }
    public void d1(string _id)
    {
       
        if(temporaryid==_id&&!LoadScene.Scenecoming)
        {
            CallFader.instance.temporarychange=true;
            CallFader.instance.Scenechange="BookOrganize";
            thistodo=true;
            
            
        }
            
            
        

    }
}
