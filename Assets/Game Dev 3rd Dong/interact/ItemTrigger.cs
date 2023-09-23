using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    private GameObject prompt;
    [Header("标识类型")]
    public GameObject promptPrefab;
    [Header("有任何触发逻辑请勾选")]
    public bool usetotrigger;
    public bool globalDisplay;
    private bool triggerin;
    private string triggerid;
    public GameObject[] RandomPrefabs;
    private Quaternion initialRotation;
    
    private Questable questable;
    private bool havequest;
    public static bool notinteract;
    public bool puzzle;
    public bool F;
    public bool E;
    private void Start()
    {
        if(transform.GetComponent<Questable>()!=null)
        {
            questable=transform.GetComponent<Questable>();
        }
        triggerid=gameObject.name;
        GameEventSystem.instance.onScenechange+=Scenechange;
    }

    private void Update()
    {
        if(prompt!=null&&globalDisplay)
        {
            prompt.transform.rotation=initialRotation;
            

        }
        if(transform.GetComponent<Questable>()!=null)
        {
            for(int i=0;i<questable.quests.Length;i++)
       {
        if(questable.enabled==true&& (questable.quests[i].questStatus==Quest.QuestStatus.Waitting||(questable.quests[i].questStatus==Quest.QuestStatus.Completed&&questable.quests[i].justTalk)))
        {
            havequest=true;
            break;
        }
        else 
        havequest=false;
       }
        if(prompt!=null&&!havequest&&!globalDisplay)
        {
             prompt.transform.GetChild(0).GetComponent<itemuianimation>().destroy();
        }
         if(prompt!=null&&!havequest&&globalDisplay&&F)
        {
             prompt.transform.GetChild(0).GetComponent<itemuianimation>().destroy();
        }
        if(prompt!=null&&notinteract&&!globalDisplay)
        {
            prompt.transform.GetChild(0).GetComponent<itemuianimation>().destroy();
        }

        }
       if(Input.GetKeyDown(KeyCode.E)||Input.GetKeyDown(KeyCode.F))
       {
        Debug.Log(notinteract);
       }
       
       if (triggerin&&(Input.GetKeyDown(KeyCode.E)&&E)&& prompt != null&&usetotrigger==true&&!notinteract)
        {
            GameEventSystem.instance.ItemTrigger(triggerid);
            print(triggerid);
            
        
        }
        if (triggerin&&(Input.GetKeyDown(KeyCode.F)&&F )&& prompt != null&&usetotrigger==true&&!notinteract)
        {
            GameEventSystem.instance.ItemTrigger(triggerid);
            print(triggerid);
            
        
        }
        if(globalDisplay&&prompt == null&&havequest&&F)
       {
            int maxTriggersamount =RandomPrefabs.Length;
            int index=Random.Range(0,maxTriggersamount);
            prompt = Instantiate(RandomPrefabs[index], transform.position + Vector3.up*0.4f, Quaternion.identity, transform);
            prompt.transform.SetParent(gameObject.transform);
       }
      

       

    }
     private void OnEnable()
    {
        Debug.Log(notinteract);
        triggerin=false;
        if(globalDisplay&&prompt == null&&E)
       {
            int maxTriggersamount =RandomPrefabs.Length;
            int index=Random.Range(0,maxTriggersamount);
            prompt = Instantiate(RandomPrefabs[index], transform.position + Vector3.up*0.4f, Quaternion.identity, transform);
            initialRotation=prompt.transform.rotation;
       }
        
    }
    private void OnDisable()
    {
        // 销毁实例化的预制件和脚本所在的 GameObject
        if ( prompt != null)
        {
            Destroy(prompt);
            //print ("销毁成功");
        }
        GameEventSystem.instance.onScenechange-=Scenechange;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&!globalDisplay&&havequest&&!notinteract)
        {  
            if(prompt!=null)
            {
                 prompt.transform.GetChild(0).GetComponent<itemuianimation>().destroy();
                
            }
            prompt = Instantiate(promptPrefab, transform.position + Vector3.up*0.4f, Quaternion.identity, transform);
            prompt.transform.SetParent(gameObject.transform);
            GameEventSystem.instance.ItemCheck(triggerid);
            triggerin=true;
            //print("触发成功");
        }
        if (other.CompareTag("Player")&&!globalDisplay&&puzzle)
        {  
            if(prompt!=null)
            {
                 prompt.transform.GetChild(0).GetComponent<itemuianimation>().destroy();
                
            }
            prompt = Instantiate(promptPrefab, transform.position + Vector3.up*0.4f, Quaternion.identity, transform);
            prompt.transform.SetParent(gameObject.transform);
            GameEventSystem.instance.ItemCheck(triggerid);
            triggerin=true;
            //print("触发成功");
        }
        else if(other.CompareTag("Player")&&globalDisplay)
        {
            GameEventSystem.instance.ItemCheck(triggerid);
            triggerin=true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")&&!globalDisplay)
        {  
            if(prompt==null&&PlayerEvent.Day==0)
            {
                
            //prompt = Instantiate(promptPrefab, transform.position + Vector3.up*0.4f, Quaternion.identity, transform);
           // prompt.transform.SetParent(gameObject.transform);
            }
           
            GameEventSystem.instance.ItemCheck(triggerid);
            triggerin=true;
            //print("触发成功");
        }
        else if(other.CompareTag("Player")&&globalDisplay)
        {
            triggerin=true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")&&!globalDisplay&&prompt!=null)
        {
           prompt.transform.GetChild(0).GetComponent<itemuianimation>().destroy();
           triggerin=false;
        }
         else if(other.CompareTag("Player")&&globalDisplay)
        {
            triggerin=false;
        }
    }
    private void Scenechange()
    {
        triggerin=false;
        if(prompt!=null)    
         prompt.transform.GetChild(0).GetComponent<itemuianimation>().destroy();
    }
}
