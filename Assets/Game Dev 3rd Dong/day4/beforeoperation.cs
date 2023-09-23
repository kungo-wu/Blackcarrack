using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class beforeoperation : MonoBehaviour
{
    private Questable questable;
    public GameObject confirmui;
    public GameObject dialogue;
    private bool one=true;
    private bool two=true;
    public GameObject cm2;
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
        if(SceneManager.GetActiveScene().name=="Clinic"&&cm2==null)
        {
             cm2=GameObject.Find("ClinicPuzzle").transform.Find("CM vcam2").gameObject;
        }
        if(two&&questable.findquest("firstmate0402 no").justTalk&&questable.findquest("firstmate0402 no").questStatus==Quest.QuestStatus.Completed&&!confirmwindow03.confirm&&!confirmwindow03.cancel)
        {
           confirmui.transform.GetChild(2).gameObject.SetActive(true);
           ItemTrigger.notinteract=true;
           two=false;
        }
           if(confirmwindow03.confirm)
        {
            ItemTrigger.notinteract=false;
            GameEventSystem.instance.Singlequest("准备手术器械");
            GameEventSystem.instance.Questupdate();
             bool justone=true;
              if(justone)
                {    Debug.Log("不够");

                     GameEventSystem.Keybd_event(70, 0, 1, 0);
                     Input.ResetInputAxes();
                     justone = false;

                }
          
                
            
            confirmwindow03.confirm=false;

        }
        if(confirmwindow03.cancel)
        {
              GameObject.Find("firstmate").GetComponent<npcstate>().death=true;
              GameObject.Find("firstmate").transform.GetChild(1).gameObject.GetComponent<Questable>().findquest("doctor05").DaytoCheck=0;
              GameEventSystem.instance.Singlequest("firstmate0403 fail");
               GameEventSystem.instance.Questupdate();
               ItemTrigger.notinteract=false;
              bool justone=true;
              if(justone)
                {    Debug.Log("不够");

                     GameEventSystem.Keybd_event(70, 0, 1, 0);
                     Input.ResetInputAxes();
                     justone = false;

                }
            confirmwindow03.cancel=false;
           
        }
       
            
        
         if(!dialogue.activeInHierarchy&&questable.findquest("准备手术器械").questStatus==Quest.QuestStatus.Accepted&&one)
             {
                
                cm2.SetActive(true);
                Camera.main.orthographic=false;
                GameEventSystem.instance.Temporarychange("准备手术器械");
                PlayerController.isPlayerInfirst=! PlayerController.isPlayerInfirst;
                one=false;

             }
        if(questable.findquest("准备手术器械").questStatus==Quest.QuestStatus.Completed&&questable.findquest("firstmate0403 success").questStatus==Quest.QuestStatus.Banned)
        {
            cm2.SetActive(false);
            GameEventSystem.instance.Temporarychange("puzzlecomplete");
             Camera.main.orthographic=true;
            ItemTrigger.notinteract=false;
            PlayerController.isPlayerInfirst=! PlayerController.isPlayerInfirst;
            GameEventSystem.instance.Singlequest("firstmate0403 success");
        }
        if(!dialogue.activeInHierarchy&&!questable.findquest("firstmate0403 success").justTalk)
        {
            GameEventSystem.instance.Temporarychange("一半钥匙");
            GameEventSystem.instance.Temporarychange("firstmatealive");
        }
        if(!dialogue.activeInHierarchy&&!questable.findquest("firstmate0403 success").justTalk&&SceneManager.GetActiveScene().name=="OldSeamanRoom")
        {
           
            StartCoroutine(firstmatealive());
        }
    }
     private IEnumerator firstmatealive()
    {
        yield return new WaitForSeconds(0.5f); // 延迟0.5秒

        // 在这里写下你想要延迟执行的函数的代码
        GameEventSystem.instance.Temporarychange("firstmatealive");
    }
}
