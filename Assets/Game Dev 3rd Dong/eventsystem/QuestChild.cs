using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestChild : MonoBehaviour
{
    
    private bool isQuestUIiopen;
    private void Start()
    {
        
      //gameObject.SetActive(false);
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            isQuestUIiopen=!isQuestUIiopen;
            

        }
        if(isQuestUIiopen)
        {
             //gameObject.SetActive(true);
        }
        //else
        //gameObject.SetActive(false);
    }

}
