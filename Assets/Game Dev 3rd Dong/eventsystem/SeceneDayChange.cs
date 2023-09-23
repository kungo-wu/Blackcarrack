using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SeceneDayChange : MonoBehaviour
{
    public string NPCname;
    public string Scenecheck;
    public int Daycheck;
    public string temporarycheck;
    
    public string temporaryreceive;
   
    private bool topositionchange;
    public bool death;
   
    public GameObject findNPC;
    private enermybehaviour enermybehaviour;
    private NavMeshAgent NavMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        GameEventSystem.instance.onDayChange+= SceneUpdate;
        GameEventSystem.instance.onTemporarychange+=  temporary;
        SceneUpdate();

        if(findNPC!=null)
        {
        enermybehaviour=findNPC .GetComponent<enermybehaviour>();
        NavMeshAgent=findNPC. GetComponent<NavMeshAgent>();

        }
        

    }
    void OnDisable()
    {
        GameEventSystem.instance.onDayChange-= SceneUpdate;
        GameEventSystem.instance.onTemporarychange-= temporary;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(CallFader.instance. temporaryupdate&&topositionchange&&!findNPC.GetComponent<npcstate>().death)//只针对触发条件后先黑屏后换位的情况
        {
            if(enermybehaviour!=null&&NavMeshAgent!=null)
            {
                enermybehaviour.enabled=false;
                NavMeshAgent.enabled=false;

            }
            print( "找到位置了");
            findNPC.transform.position=new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z);
            findNPC.transform.rotation=gameObject.transform.rotation;
              
            if(enermybehaviour!=null&&NavMeshAgent!=null)
            {
                 enermybehaviour.enabled=true;
                 NavMeshAgent.enabled=true;

            }
            GameEventSystem.instance.Temporarychange(temporarycheck);  
            
            topositionchange=false;

             

        }
        
        
    }
    public void SceneUpdate()
    {
        findNPC=GameObject.Find(NPCname);
        if(Daycheck==PlayerEvent.Day&&NPCname!=""&&temporaryreceive==""&&temporarycheck==""&&!findNPC.GetComponent<npcstate>().death)
        {
            if(enermybehaviour!=null&&NavMeshAgent!=null)
            {
                //enermybehaviour.enabled=false;
                NavMeshAgent.enabled=false;

            }
            
            findNPC.transform.position=new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z);
            findNPC.transform.rotation=gameObject.transform.rotation;
            //CallFader.instance.temporarychange=true;
            if(enermybehaviour!=null&&NavMeshAgent!=null)
            {
                 //enermybehaviour.enabled=true;
                 NavMeshAgent.enabled=true;

            }
        }
            if(Daycheck==PlayerEvent.Day&&NPCname!=""&&findNPC.GetComponent<npcstate>().death&&death)
        {
            if(enermybehaviour!=null&&NavMeshAgent!=null)
            {
                //enermybehaviour.enabled=false;
                NavMeshAgent.enabled=false;

            }
            
            findNPC.transform.position=new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z);
            findNPC.transform.rotation=gameObject.transform.rotation;
            findNPC.transform.GetChild(2).gameObject.GetComponent<Animator>().enabled=false;
            findNPC.transform.GetChild(1).gameObject.GetComponent<Questable>().enabled=false;
            GameEventSystem.instance.Temporarychange(temporarycheck);
            GameEventSystem.instance.Singlequest(temporarycheck);
            GameEventSystem.instance.Questupdate();
            //CallFader.instance.temporarychange=true;
            if(enermybehaviour!=null&&NavMeshAgent!=null)
            {
                 //enermybehaviour.enabled=true;
                 NavMeshAgent.enabled=true;

            }
            
        }
            
        
        

    }

  
     public void temporary(string _id)
     {
       
        if(temporaryreceive==_id&&temporaryreceive!="")
        {
            findNPC=GameObject.Find(NPCname);
            print( "找到位置了");
            CallFader.instance.temporarychange=true;
            topositionchange=true;
            //该用于通知navmesh开始移动
            
           
            

        }
     }
}
