using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class afterfindfeather : MonoBehaviour
{
    private Questable questable;
    public GameObject confirmui;
    public GameObject dialogue;
    private bool one=true;
    private bool two=true;
    // Start is called before the first frame update
    void Start()
    {
        questable=GetComponent<Questable>();
        confirmui= GameObject.Find("Confirm");
        GameObject parentObj = GameObject.Find("Dialogue");
        GameObject bbb = parentObj.transform.Find("DialogueAndPointer").gameObject;
        dialogue=bbb;

        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(two&&questable.findquest("firstmate0302 no").justTalk&&questable.findquest("firstmate0302 no").questStatus==Quest.QuestStatus.Completed&&!confirmwindow02.confirm&&!confirmwindow02.cancel)
        {
           confirmui.transform.GetChild(1).gameObject.SetActive(true);
           ItemTrigger.notinteract=true;
           two=false;
        }
           if(confirmwindow02.confirm)
        {
            GameEventSystem.instance.Singlequest("firstmate0302 yes");
            GameEventSystem.instance.Questupdate();
            ItemTrigger.notinteract=false;
             bool justone=true;
              if(justone)
                {    Debug.Log("不够");

                     GameEventSystem.Keybd_event(70, 0, 1, 0);
                     Input.ResetInputAxes();
                     justone = false;

                }
          
                
             
            confirmwindow02.confirm=false;

        }
        if(confirmwindow02.cancel)
        {
              ItemTrigger.notinteract=false;
              bool justone=true;
              if(justone)
                {    Debug.Log("不够");

                     GameEventSystem.Keybd_event(70, 0, 1, 0);
                     Input.ResetInputAxes();
                     justone = false;

                }
            confirmwindow02.cancel=false;
           
        }
       
            
        
         if(!dialogue.activeInHierarchy&&!questable.findquest("firstmate0302 yes").justTalk&&one&&PlayerEvent.Day==3)
             {
                
                GameEventSystem.instance.Temporarychange("day03afterafter") ;
                one=false;

             }
    }
}
