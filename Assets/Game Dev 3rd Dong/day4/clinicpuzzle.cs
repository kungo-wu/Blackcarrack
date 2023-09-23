using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clinicpuzzle : MonoBehaviour
{
     public static List<GameObject> getinitems=new List<GameObject>();
    private bool isadsorption;
    private bool one=true;
    public GameObject positionpoint;
    public List<GameObject> items=new List<GameObject>();
    private Vector3 relativeposition;
    public static List<GameObject> childs=new List<GameObject>();
    public bool unfinished;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(childs.Count);
         if(items!=null&&isadsorption&&!transform.parent.GetComponent<cooperationforclinic>().isdrag&&childs.Count==transform.parent.childCount)
        {
            
            if(gameObject.CompareTag("positiontarget")&&one)
            {
                relativeposition=positionpoint.transform.position-gameObject.transform.position;
                gameObject.transform.parent.transform.position +=relativeposition+new Vector3(0,0.25f,0);
                Debug.Log(relativeposition);               
                childs.Clear();
                if(!getinitems.Contains(transform.parent.gameObject))
                getinitems.Add(transform.parent.gameObject);
                one=false;
                
            
            }
            
        }
        if(transform.parent.GetComponent<cooperationforclinic>().isdrag)
        {
           if(getinitems.Contains(transform.parent.gameObject))
                getinitems.Remove(transform.parent.gameObject);  
            unfinished=true;
            one=true;
            
        }
        else
        {
            
            unfinished=false;
        }
        
        if(childs.Count==transform.parent.childCount&&unfinished)
        {
              transform.parent.GetComponent<cooperationforclinic>().catched=true;
        }
        else 
        {
             transform.parent.GetComponent<cooperationforclinic>().catched=false;
        }
        if(getinitems.Count==5)
        {
            
            GameEventSystem.instance.EventCompleted("准备手术器械");
        }
    }
    private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("drag")&&unfinished&&other.gameObject.GetComponent<pointcontrol>().justone)
        {
           Debug.Log(other.gameObject.GetComponent<pointcontrol>().justone+""+other.name);
            if(!items.Contains(other.gameObject))
            {
                    Debug.Log("调用一次");
                    items.Add(other.gameObject);
                    childs.Add(gameObject);
                   
                    
            }
             if(!childs.Contains(other.gameObject))
             {
                
             }
            if(gameObject.CompareTag("positiontarget"))    
            {
                positionpoint=other.gameObject;
            }
                
            
            //Debug.Log("成功");
            if(!isadsorption)
            {
                
                isadsorption=true;

            }
           
        }
    }
     private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("drag"))
        {
           
                if(items.Contains(other.gameObject))
                {
                   items.Remove(other.gameObject);
                   childs.Remove(gameObject);
                }
                if(childs.Contains(other.gameObject))
                {
                    

                }
                
                if(gameObject.CompareTag("positiontarget"))    
            {
                positionpoint=null;
            }
            }
            
            
            //Debug.Log("成功");
            isadsorption=false;           
            //one=true;
           
            
        }
    
}
