using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkSystem : MonoBehaviour
{
    [TextArea(1,3)]
    private string[] lines;
    private BoxCollider _collider;
    private bool cantalk;
    
    private string Talkid;
    [Header("挂载对话UI")]
    [Header("对话系统需要挂载Questable")]
    public GameObject dialogue;
    private Questable questable;
    private string nowquestName;

    private bool ischeck;
    public static bool cansee;
    private bool toshow;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject parentObj = GameObject.Find("Dialogue");
        GameObject bbb = parentObj.transform.Find("DialogueAndPointer").gameObject;
        dialogue=bbb;
        Talkid=gameObject.name;
        questable =gameObject.GetComponent<Questable>();
        _collider = GetComponent<BoxCollider>();
       OnEnable() ;
        
        
    }
    private void OnEnable() 
    {
        GameEventSystem.instance.onItemTrigger+=Talk;
        GameEventSystem.instance.onDialogueFinish+=DelegateQuestNotice;
        GameEventSystem.instance.onItemCheck+=IdCheck;
    }
     private void OnDisable()
    {
        GameEventSystem.instance.onItemTrigger-=Talk;
        GameEventSystem.instance.onDialogueFinish-=DelegateQuestNotice;
        GameEventSystem.instance.onItemCheck-=IdCheck;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Talk(string _talkid)//订阅当靠近物体且与其发生交互时事件，传入核查对象id参数
    {   if(Talkid==_talkid)
      {
        print(_talkid);
        if(dialogue.activeInHierarchy==false)
        {
          
          for(int i=0;i<questable.quests.Length;i++)
         {print(questable.quests[i].questName);

          if(!questable.quests[i].justTalk&&questable.quests[i].questStatus==Quest.QuestStatus.Waitting)//对于非justtalk，当它为等待状态时将任务的对话加载（由于之前的逻辑一般来说同一对象任务列表有且仅有一个任务为等待状态）
          {
            lines=questable.quests[i].questlines;
            nowquestName=questable.quests[i].questName;//标记目前对话任务，为后面传入参数准备
            GameEventSystem.instance.DialogueStart(questable.quests[i].nextquestName);//启用对话开始事件，将目前任务内的下一个任务名参数传入，该为非justtalk传入justtalk 的情况事件调用
            print("非justtalk传talk");
           
              dialogue.SetActive(true);
              DialogueScript.instance.LoadDialogue(lines);
            
            
            
            break;
          }
          else if(questable.quests[i].justTalk&&questable.quests[i].questStatus==Quest.QuestStatus.Completed)//对于justtalk需要在其为完成状态时调用，由于会有众多已经完全完成的justtalk，对于
                                                                                                             //justtalk来说只有其对话被加载时才能算作完全完成，因此对话加载后将该任务的justtalk取反来代表其完全完成
          {
            print(questable.quests[i].nextquestName);
            
            lines=questable.quests[i].questlines;
            nowquestName=questable.quests[i].questName;
            GameEventSystem.instance.DialogueStart(questable.quests[i].nextquestName);
            questable.quests[i].justTalk=!questable.quests[i].justTalk;
           
              dialogue.SetActive(true);
              DialogueScript.instance.LoadDialogue(lines);
            
           
            break;
            
          }
       
         }
           
           
        }
      }
    }
    private void IdCheck(string _idcheckid) //核查对象id来控制只让我们目前在交互的对象进行任务分发
    {
      if(Talkid==_idcheckid)
      {
        ischeck=true;

      }
      else
      {
        ischeck=false;
      }
    }
    public void DelegateQuestNotice()
    {
      if(ischeck==true)
      {
        //print("Talkid测试"+Talkid);
        QuestUIManager.instance.UpdateQuestList();
        GameEventSystem.instance.GatheringUpdate(nowquestName); //任务分发开始时开始收集任务更新事件   
        GameEventSystem.instance.DelegateQuest(Talkid ,nowquestName);//开始任务分发事件，为什么不给该函数添加核查对象id参数呢，因为对话完成的事件在对话系统中触发，而对话系统作为UI无法传入id参数
        GameEventSystem.instance.JustTalkFinished(Talkid ,nowquestName);//开始同一对象下的同一系列含有justtalk 的justtalk更新

      }
      
    }
}
