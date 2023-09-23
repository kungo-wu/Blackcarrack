using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class merchant : MonoBehaviour
{
    private Questable questable;
    public GameObject confirmui;
    public GameObject dialogue;
    private bool one=true;
    private bool two=true;
    // Start is called before the first frame update
    void Start()
    {
        confirmui= GameObject.Find("Confirm");
        questable=gameObject.GetComponent<Questable>();
        GameObject parentObj = GameObject.Find("Dialogue");
        GameObject bbb = parentObj.transform.Find("DialogueAndPointer").gameObject;
        dialogue=bbb;
    }

    // Update is called once per frame
    void Update()
    {
        if(two&&questable.findquest("merchant and servant 02daytarger refuse").justTalk&&questable.findquest("merchant and servant 02daytarger refuse").questStatus==Quest.QuestStatus.Completed&&!confirmwindow.confirm&&!confirmwindow.cancel)
        {
           confirmui.transform.GetChild(0).gameObject.SetActive(true);
           ItemTrigger.notinteract=true;
           two=false;
        }
        if(confirmwindow.confirm)
        {
            GameEventSystem.instance.Singlequest("去地下室修补");
            GameEventSystem.instance.Questupdate();
            ItemTrigger.notinteract=false;
             bool justone=true;
              if(justone)
                {    Debug.Log("不够");

                     GameEventSystem.Keybd_event(70, 0, 1, 0);
                     Input.ResetInputAxes();
                     justone = false;

                }
            
                

            confirmwindow.confirm=false;

        }
        if(confirmwindow.cancel)
        {
            GameObject.Find("merchant").GetComponent<npcstate>().death=true;
            GameObject.Find("servant").GetComponent<npcstate>().death=true;
            ItemTrigger.notinteract=false;
             bool justone=true;
              if(justone)
                {    Debug.Log("不够");

                     GameEventSystem.Keybd_event(70, 0, 1, 0);
                     Input.ResetInputAxes();
                     justone = false;

                }
            confirmwindow.cancel=false;
            
        }
         if(!dialogue.activeInHierarchy&&questable.findquest("去地下室修补").questStatus==Quest.QuestStatus.Accepted&&one)
             {
                CallFader.instance.temporarychange=true;
                CallFader.instance.Scenechange="Basement";
                GameEventSystem.instance.Temporarychange("basementrepair");
                one=false;

             }
    }
}
