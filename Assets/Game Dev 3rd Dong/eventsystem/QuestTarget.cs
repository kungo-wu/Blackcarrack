using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTarget : MonoBehaviour
{
    public string questName;
    private string targetid;
    public enum QuestType{Gathering,Talk,Reach,Event};
    public QuestType questType;
    [Header("如果选择Gathering类型选择所需物品")]
    public item targetItem;
    private bool ischeck;
    
    
    private bool hasGatherred;

    
    private bool hasTalked;
    
    
    private bool hasReached;

    
    private bool hassucceed;
    void Start()
    {
        targetid=gameObject.name;
        GameEventSystem.instance.onEventCompleted+=EventCompleted;
        GameEventSystem.instance.onItemCheck+=IdCheck;
        GameEventSystem.instance.onDialogueFinish+=TalkFinished;
        GameEventSystem.instance.onDialogueFinish+=QuestComplete;
        GameEventSystem.instance.onDialogueCheck+= DialogueCheck;
        
    }
    
     private void OnDisable()
    {
        GameEventSystem.instance.onEventCompleted-=EventCompleted;
        GameEventSystem.instance.onItemCheck-=IdCheck;
        GameEventSystem.instance.onDialogueFinish-=TalkFinished;
        GameEventSystem.instance.onDialogueFinish-=QuestComplete;
        GameEventSystem.instance.onDialogueCheck-= DialogueCheck;
        
    }

    public void  QuestComplete()//任务完成函数
    {
        if(PlayerEvent.instance.questList!=null)
        {
        for(int i=0; i<PlayerEvent.instance.questList.Count; i++)
        {
            

            if(questName==PlayerEvent.instance.questList[i].questName)
            {
               
                switch (questType)
                {
                case QuestType.Gathering://该任务完成逻辑已不启用
                    if(targetItem.itemamount>=PlayerEvent.instance.questList[i].requireAmount&&PlayerEvent.instance.questList[i].questStatus==Quest.QuestStatus.Accepted)
                    {
                        PlayerEvent.instance.questList[i].questStatus=Quest.QuestStatus.Completed;
                        QuestUIManager.instance.UpdateQuestList();
                        GameEventSystem.instance.TargetCompleted(questName);
                        
                    }
                    break;

                case QuestType.Talk:
                    if(hasTalked&&PlayerEvent.instance.questList[i].questStatus==Quest.QuestStatus.Accepted)
                    {
                        PlayerEvent.instance.questList[i].questStatus=Quest.QuestStatus.Completed;
                        QuestUIManager.instance.UpdateQuestList();
                        GameEventSystem.instance.TargetCompleted(questName);//将完成的任务名传入任务完成事件
                        
                    }
                    break;

                case QuestType.Reach:
                    if(hasReached &&PlayerEvent.instance.questList[i].questStatus==Quest.QuestStatus.Accepted)
                    {
                        PlayerEvent.instance.questList[i].questStatus=Quest.QuestStatus.Completed;
                        QuestUIManager.instance.UpdateQuestList();
                        GameEventSystem.instance.TargetCompleted(questName);
                        
                    }
                    break;
                case QuestType.Event:
                    if(hassucceed &&PlayerEvent.instance.questList[i].questStatus==Quest.QuestStatus.Accepted)
                    {
                        PlayerEvent.instance.questList[i].questStatus=Quest.QuestStatus.Completed;
                        QuestUIManager.instance.UpdateQuestList();
                        GameEventSystem.instance.TargetCompleted(questName);
                        Debug.Log("Event调用");  
                        
                    }
                    break;
                }

            }
            
            
        }
        }
    }
     private void OnTriggerEnter(Collider other) //简单的达到完成逻辑，单独写了触发器，因此不需要挂载itemtrigger脚本
    {
            if(other.CompareTag("Player"))
            {
                
                if(questType==QuestType.Reach)
                {
                    hasReached=true;
                    QuestComplete();
                }
            }
            
            
    }
     private void IdCheck(string _checkid)
    {
      if(targetid!=null&& targetid==_checkid)
      {
        ischeck=true;
        

      }
      else
      {
        ischeck=false;
      }
    }

    public void TalkFinished()//核查对象id后，将所需完成任务名传入对话核对事件
    {
       if(ischeck)
        GameEventSystem.instance.DialogueCheck(questName);
         print("TalkFinished检测完成");
       
    }
    public void DialogueCheck(string _dialoguecheckid)//订阅的时对话完成事件，请不要与前者的事件触发搞混，将对象的任务名与目前对话的任务名核对
    {
        
        if(questName==_dialoguecheckid)
        {
            
            hasTalked=true;
            QuestComplete();
            
        }
    }
    public void EventCompleted(string _eventcompleteid)//订阅事件完成事件，传入完成的事件任务名，注意事件完成的触发逻辑写在每个日课任务逻辑当中
    {
        if(questName==_eventcompleteid)
        {
            hassucceed=true;
            
            QuestComplete();

        }
       
    }
    private void Update()
    {
        
    }


}
