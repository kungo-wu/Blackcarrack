using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class enermybehaviour : MonoBehaviour
{
    public Transform patrolroute;
    public List<Transform> locations;

    public NavMeshAgent agent;
    private int locaitonindex=0;
    private Transform player;
    private bool ischasing;
    private Animator _playerAnimator;
    
    public bool needchase;
    private  bool tomove=false;
    public string NPCname;
    public string[] temporarycheckname;
    public Questable questable;
     public GameObject dialogue;
    public GameObject qte1;
    public GameObject qte2;
    private bool second;
    public bool collision;
    void Initializepatrolroute()
    {
        foreach(Transform child in patrolroute)
        {
            locations.Add(child);
        }
    }
    void MoveToNextPatrolLocation()
    {

        _playerAnimator=gameObject.transform.GetChild(2).GetComponent<Animator>();
        agent.destination=locations[locaitonindex].position;
        locaitonindex=(locaitonindex+1)%locations.Count;
        _playerAnimator.SetTrigger("chase");
        if(ischasing==true)
        {  
           transform.LookAt(player);
        }
    }
    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.name=="Player"&&agent.enabled==true)
        {
           agent.destination=player.position;
           ischasing=true;
           Debug.Log(gameObject.name);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name=="Player"&&agent.enabled==true)
        {
            
            agent.destination=locations[locaitonindex].position;
            ischasing=false;
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
         if(other.gameObject.name=="Player")
         {
            collision=true;
            agent.speed=0;
             _playerAnimator.ResetTrigger("chase");
             bool justone=true;
              if(justone)
                {    Debug.Log("不够");

                     GameEventSystem.Keybd_event(70, 0, 1, 0);
                     Input.ResetInputAxes();
                     justone = false;

                }
                if(questable.findquest("catched")!=null)
                {
                    if(questable.findquest("catched").justTalk)
                {
                    questable.findquest("catched").justTalk=false;
                    
                }
                }
                if(questable.findquest("oldseaman0501")!=null)
                {
                    if(questable.findquest("oldseaman0501").justTalk)
                {
                    questable.findquest("oldseaman0501").justTalk=false;
                }
                PlayerController.isPlayerInfirst=true;
                }
                
                
         }
    }
    private void OnCollisionExit(Collision other) 
    {
        if(other.gameObject.name=="Player")
         {
            if(collision)
            {
                 _playerAnimator.SetTrigger("chase");
                collision=false;
            }
           
            second=true;
         }
    }
    // Start is called before the first frame update
    void Start()
    {
        NPCname=gameObject.name;
        agent=gameObject.GetComponent<NavMeshAgent>();
        //agent.enabled=false;
        _playerAnimator =gameObject. GetComponent<Animator>();
        GameEventSystem.instance.onTemporarychange+= temporarycheck;
        GameEventSystem.instance.onQTEfinished+=qteafter;
        questable=gameObject.transform.GetChild(1).GetComponent<Questable>();
        GameObject parentObj = GameObject.Find("Dialogue");
        GameObject bbb = parentObj.transform.Find("DialogueAndPointer").gameObject;
        dialogue=bbb;
        if(patrolroute!=null)
        Initializepatrolroute();

    
        
    }
    void OnDisable()
    {
       
    }
    private void Update() 
    {
        if(second&&!dialogue.activeInHierarchy)
        {
            agent.speed=4f;
            second=false;
        }
        if(questable!=null&&questable.findquest("catched")!=null)
        {
            if(!dialogue.activeInHierarchy&&!questable.findquest("catched").justTalk)
             {
                
                CallFader.instance.temporarychange=true;
                CallFader.instance.Scenechange=SceneManager.GetActiveScene().name;
                PlayerController.isPlayerInfirst=false;
                questable.findquest("catched").justTalk=true;

             }

        }
        if(questable!=null&&questable.findquest("oldseaman0501")!=null)
        {
            if(qte1!=null)
            {
                 if(!dialogue.activeInHierarchy&&!questable.findquest("oldseaman0501").justTalk&&!qte1.activeInHierarchy&&SceneManager.GetActiveScene().name=="SecretRoomWithEye")
             {
                
                {
                    qte1.SetActive(true);
                    PlayerController.isPlayerInfirst=false;
                    ItemTrigger.notinteract=true;
                    DialogueScript.notdialogue=true;
                    GameEventSystem.instance.Singlequest("oldseaman0502");
                    GameEventSystem.instance.Questupdate();
                }
             }

            }
            
             if(qte2!=null)
             {
                if(!dialogue.activeInHierarchy&&!questable.findquest("oldseaman0502").justTalk&&!qte2.activeInHierarchy)
             {
                
                {

                    qte2.SetActive(true);
                    ItemTrigger.notinteract=true;
                    
                }

             }

             }
             
        }
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(agent.enabled==true)
        {
            player=GameObject.FindWithTag("Player").transform;
        if(needchase)
        {
            
            if(locations.Count==0&&ischasing==false)
        {
            return;
        }
        if(agent.remainingDistance<0.2f&&!agent.pathPending&&ischasing==false)
        {

            MoveToNextPatrolLocation();
            
        }

        }

        }
        
        
        
       
           
        
        
    }
    public void temporarycheck(string _id)
    {
        
        
        for(int i=0;i<temporarycheckname.Length;i++)
        {
           
            if(temporarycheckname[i]==_id)
            {
                 patrolroute=GameObject.FindWithTag(NPCname).GetComponent<Transform>();
                 if(patrolroute==null)
                 break;
                Initializepatrolroute();
               agent.enabled=false;
               agent.enabled=true;
                
                
                
            }
            
        }
    }
    public void qteafter()
    {
        
        DialogueScript.notdialogue=false;
        ItemTrigger.notinteract=false;
        bool justone=true;
              if(justone)
                {    Debug.Log("不够");

                     GameEventSystem.Keybd_event(70, 0, 1, 0);
                     Input.ResetInputAxes();
                     justone = false;

                }
                
    }
}
