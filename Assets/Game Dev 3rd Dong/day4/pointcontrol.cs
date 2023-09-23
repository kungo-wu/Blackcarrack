using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointcontrol : MonoBehaviour
{
    public bool justone;
    public List<GameObject> items=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(items.Count==0)
        {
            justone=true;
        }
        else 
        {
            justone=false;
        }
    }
    private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("target")||other.CompareTag("positiontarget"))
        {
           
            if(!items.Contains(other.gameObject))
            {
                    Debug.Log("调用一次");
                    items.Add(other.gameObject);
                    
                   
                    
            }
             
           
                
            
           
           
        }
    }
     private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("target")||other.CompareTag("positiontarget"))
        {
           
                if(items.Contains(other.gameObject))
                {
                   items.Remove(other.gameObject);
                   
                }
              
                
           
            }
            
            
          
           
            
        }
    
}
