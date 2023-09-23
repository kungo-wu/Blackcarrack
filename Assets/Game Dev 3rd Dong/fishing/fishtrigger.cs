using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishtrigger : MonoBehaviour
{
    public GameObject fishing;
    private GameObject prompt;
    public GameObject promptPrefab;
    private GameObject player;
    private bool click;
    void Start()
    {
        player=GameObject.Find("Player");
    }
    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.E) && prompt != null)
        {
          finishicontrol.isfinish=!finishicontrol.isfinish; 
          PlayerController.isPlayerInfirst=!PlayerController.isPlayerInfirst; 
          click=!click;
          if(click)
        {
          player.transform.rotation=new Quaternion(0,-0.999322057f,0,-0.0368180759f);
          GameEventSystem.instance.Singlequest("fishcomplete01");    
          
          GameEventSystem.instance.Temporarychange("fishstart");
          player.GetComponent<Animator>().SetTrigger("Fishing");
         

        }
        else
        {
        
          player.GetComponent<Animator>().ResetTrigger("Fishing");
         
        }
        }
        
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {  
            prompt = Instantiate(promptPrefab, transform.position + Vector3.up*0.4f, Quaternion.identity, transform);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           prompt.transform.GetChild(0).GetComponent<itemuianimation>().destroy();
        }
    }
}
