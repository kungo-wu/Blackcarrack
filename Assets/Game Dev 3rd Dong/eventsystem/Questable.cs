using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Questable : MonoBehaviour
{
    public Quest[] quests;
    private Quest nowquest;
    private Quest findoutquest;
    private string Questid;
    private Quest receivequest;
    public Quest lastquest;
    private bool nosamequests=true;

    private void Start()
    {
        Questid=gameObject.name;

        OnEnable() ;
        EventUpdate();
        progressupdate();
    }
    private void OnEnable() 
    {
        
        GameEventSystem.instance.onDayChange+= EventUpdate;
        GameEventSystem.instance.onDialogueStart+=NextQuestUpdateFuture;
        GameEventSystem.instance.onTargetCompleted+=NextQuestUpdateDone;
        GameEventSystem.instance.onDelegateQuest+=DelegateQuest;
        GameEventSystem.instance.onGatheringUpdate+= GatheringUpdate;
        GameEventSystem.instance.onJustTalkFinished+=justTalkUpdate;
        GameEventSystem.instance.onSinglequest+=Singlequest;
        GameEventSystem.instance.onQuestupdate+=progressupdate;
        GameEventSystem.instance.onDayChange+= progressupdate;
    }
    
    private void OnDisable()
    {
        GameEventSystem.instance.onDayChange-= EventUpdate;
        GameEventSystem.instance.onDialogueStart-=NextQuestUpdateFuture;
        GameEventSystem.instance.onTargetCompleted-=NextQuestUpdateDone;
        GameEventSystem.instance.onDelegateQuest-=DelegateQuest;
        GameEventSystem.instance.onGatheringUpdate-= GatheringUpdate;
        GameEventSystem.instance.onJustTalkFinished-=justTalkUpdate;
        GameEventSystem.instance.onSinglequest-=Singlequest;
        GameEventSystem.instance.onQuestupdate-=progressupdate;
        GameEventSystem.instance.onDayChange-=progressupdate;
    }
    public void DelegateQuest(string _delegatequestid ,string _nowquestid)//用于分派任务，在任务分派事件发生时被通知，被传入第一个参数为目前交互对象id第二个参数不参与运算
    {
        
        if(Questid==_delegatequestid&&_delegatequestid!=null&&_nowquestid!=null)
        {
            print("比较成功");
        for(int i=0;i<quests.Length;i++)
        {
            
         if(!quests[i].justTalk&&quests[i].questStatus==Quest.QuestStatus.Waitting)//非justtalk类，若为等待状态则加入到角色任务栏中
         {   
             PlayerEvent.instance.questList.Add(quests[i]);
             quests[i].questStatus=Quest.QuestStatus.Accepted;
             nowquest= quests[i];
             print("a");
             
         }
         else if(!quests[i].justTalk&&quests[i].questType==Quest.QuestType.Gathering&&quests[i].questStatus==Quest.QuestStatus.Completed&&quests[i]!=nowquest)//非justtalk类且提前完成的收集类任务也加入到任务栏中，防止重复加入要确认任务栏中尚不存在同名任务
         {
            PlayerEvent.instance.questList.Add(quests[i]);
            nowquest= quests[i];
            print("b");
             
         }
       
         else if(quests[i].justTalk&&quests[i].questStatus==Quest.QuestStatus.Waitting)//对于justtalk类型任务不需要加入到任务栏中
         {
            print("c");
         }
         else
         {
            print("d");
        
         }
        }
    
        }
        else
        {
             print("传参失败");
        }
    }
    private void GatheringUpdate(string _gatheringupdateid) //更新收集类任务状态，订阅收集类更新时事件，传入目前更新的收集类任务名
    {
       
        for(int i=0;i<quests.Length;i++)
        {
            if(_gatheringupdateid!=null&&quests[i].itemTarget!=null&& quests[i].itemTarget.itemamount>=quests[i].requireAmount&&quests[i].questName==_gatheringupdateid) //确认收集数量达到要求且与所要更新的任务名相同
                    {
                        quests[i].questStatus=Quest.QuestStatus.Completed;
                        QuestUIManager.instance.UpdateQuestList();//更新任务栏UI
                        GameEventSystem.instance.TargetCompleted(quests[i].questName);//启用任务完成时事件，传入所完成任务名
                        
                    }
        }

    }
    private void NextQuestUpdateFuture(string _nextquestupdateid)//在对话开始时更新任务状态，被传入下一个任务名参数，由于非justtalk任务都会在对话结束时再开始更新任务状态因此
                                                                //，该函数仅针对justtalk类型的更新逻辑,justtalk类型talk任务需要在对话一开始获取到正在对话的任务名，更新自身状态，此类型只存两种状态
                                                                //banned和completed状态，因此对话的加载对于该类型会在该类型处于完成状态时加载
                                                                
    {
        print("FUTURE"+_nextquestupdateid+Questid);
        for(int i=0;i<quests.Length;i++)
        {
            if(quests[i].nextquestName==_nextquestupdateid&&quests[i].nextquestName!="")//如果justtalk类型不是作为任务流程首个任务，那么会存在多种情况
                                                                                      // 非justtalk传给justtalk和justtalk传给talk，该函数仅负责非justtalk传给talk
                                                                                       //此情况存在两种情况，同一对象下和不同对象下，如果是同一对象下，那么代表着这是一系列的任务
                                                                                       //如果是一系列的任务，那么有另外一套逻辑处理状态，我们这里需要处理不同状态下，我们首先要区分是否是同一对象下
                                                                                       
            {
                 receivequest=quests[i];
                 NextQuestUpdateDone(quests[i].questName);
                 nosamequests=false;  
                  print("相同"); 
                 break;  
            }              
            
         
        }
        if(nosamequests)                                                              //由于事件一旦通知是通知所有目标下的该函数，即使做了对象核查也会存在，如果一个对话任务需要和另外一个
                                                                                         //人的justtalk对接，即使有着下一任务名作为区分，也会导致同一对象下的含有justtalk的系列任务也开始更新状态
                                                                                         //这是我们不能接受的，因为同一系列下的任务一定是前者完成之后后者才能够进行的，如果不做同一对象下区分，会导致
                                                                                         //同一系列的任务内的justtalk提前被完成
        {
            print("不同"); 
             for(int i=0;i<quests.Length;i++)
           {
             if(quests[i].questName==_nextquestupdateid&&quests[i].justTalk)
             {
                lastquest=quests[i];
                quests[i].questStatus=Quest.QuestStatus.Completed;//justtalk只存在banned和completed状态，因此需要对应传入参数——下一个任务名的justtalk更新为完成状态
                NextQuestUpdateDone(quests[i].questName);//该任务完成后交付给完成时下一任任务更新函数
             }
             else if(quests[i].questName==_nextquestupdateid&&!quests[i].justTalk&&quests[i].questStatus==Quest.QuestStatus.Banned)//非同一对象justtalk传给非justtalk
             {
                
                quests[i].questStatus=Quest.QuestStatus.Waitting;
                EventUpdate();

             }
           }
        }
        print("FUTURE下一任务更新完成");                             
    }
    private void NextQuestUpdateDone(string _nextquestupdateid)//订阅任务完成时事件，传入已经完成的任务名参数
    {
        //print("DONE"+_nextquestupdateid);
        for(int i=0;i<quests.Length;i++)
        {
            if(_nextquestupdateid!=null&&quests[i].questName==_nextquestupdateid&&quests[i].questStatus==Quest.QuestStatus.Completed)//在该对象的任务列表查找到已经被完成的任务，做好标记
            {
                findoutquest=quests[i];      
                for(int j=0;j<quests.Length;j++)
            {
             if(_nextquestupdateid!=null&&quests[j].questName==findoutquest.nextquestName&&findoutquest.nextquestName!=null&&quests[j].questStatus==Quest.QuestStatus.Banned)//将完成任务中的下一个任务名作为参数，更新下一个应该接取的任务状态为等待中
             {
                
                quests[j].questStatus=Quest.QuestStatus.Waitting;
                
             }

            }        
            
            }
         print("DONE下一任务更新完成");
         
        }                              
    }
    private void EventUpdate()//事件类型任务更新
    {
        //
        for(int i=0;i<quests.Length;i++)
        {
            if(quests[i].EventAuto&& quests[i].DaytoCheck==PlayerEvent.Day&&PlayerEvent.Day!=1&&quests[i].questStatus==Quest.QuestStatus.Banned)//确认天数为所需天数，则更新该任务状态为等待，并在一开始调用，订阅天数更改事件
            {
                
                quests[i].questStatus=Quest.QuestStatus.Waitting;
                
            }
  
         
         
        }
        for(int i=0;i<quests.Length;i++)
        {
            
         if(quests[i].DaytoCheck==PlayerEvent.Day&&quests[i].questType==Quest.QuestType.Event&&quests[i].questStatus==Quest.QuestStatus.Waitting)//事件类型任务需要单独更新并添加至任务栏，因为前者任务添加函数是基于对话结束事件的我们需要在天数以改变时添加
         {   
             PlayerEvent.instance.questList.Add(quests[i]);
             quests[i].questStatus=Quest.QuestStatus.Accepted;
             
         }        
         else
         {
           
         }
        }                      
    }
    private void justTalkUpdate(string _justtalkupdateid,string _justtalkquestid)            /*订阅更新Justtalk类型时事件，传入核对对象id参数和正在对话任务名参数 
                                                                                                该函数主要负责同一对象时任务列表含有justtalk 的情况，上者的函数已经标记了当前完成的任务
                                                                                                此时由于时同一对象，按照上者的任务更新函数，内的justtalk会存在短暂的等待状态，更新其为完成状态，
                                                                                                并调用任务完成时更新任务函数*/
    {
        print("无justtalk更新");
        if(_justtalkupdateid!=null&& _justtalkquestid!=null&&Questid==_justtalkupdateid)
        {
        print(_justtalkupdateid+_justtalkquestid);
        for(int i=0;i<quests.Length;i++)
        {
            if(quests[i].justTalk&&quests[i].questStatus==Quest.QuestStatus.Waitting&&quests[i].questName==findoutquest.nextquestName)
            {
                
                quests[i].questStatus=Quest.QuestStatus.Completed;
                NextQuestUpdateDone(quests[i].questName);
                print("循环一次");
                break;
            }
            
            else
            {
               
            }
            
                   
        }
        }
   
        
        

    }
    public void Singlequest(string _questid)
    {
       
        print(_questid);
        for(int i=0;i<quests.Length;i++)
        {
            if(quests[i].justTalk&&quests[i].questStatus==Quest.QuestStatus.Banned&&quests[i].questName==_questid)
            {
                quests[i].questStatus=Quest.QuestStatus.Completed;
                if(GetComponent<BoxCollider>()!=null)
                {
                GetComponent<BoxCollider>().enabled=false;
                GetComponent<BoxCollider>().enabled=true;

                }
               
                //NextQuestUpdateDone(quests[i].questName);
            }
            else if(!quests[i].justTalk&&quests[i].questStatus==Quest.QuestStatus.Banned&&quests[i].questName==_questid)
            {
                quests[i].questStatus=Quest.QuestStatus.Waitting;
               if(GetComponent<BoxCollider>()!=null)
                {
                GetComponent<BoxCollider>().enabled=false;
                GetComponent<BoxCollider>().enabled=true;

                }
               
                //NextQuestUpdateDone(quests[i].questName);
            }
        }

    }
    public void progressupdate()
    {
        for(int i=0;i<quests.Length;i++)//天数更新也算一种事件，这里还是分开更新，不过不需要全部更新，只更新这个天数开始需要的第一个任务，是否只需要设置第一个任务的天数即可？
        {
            if(quests[i].DaytoCheck==PlayerEvent.Day&&PlayerEvent.Day!=0&&quests[i].questStatus==Quest.QuestStatus.Banned&&!quests[i].EventAuto)//确认天数为所需天数，则更新该任务状态为等待，并在一开始调用，订阅天数更改事件
            {
                
                quests[i].questStatus=Quest.QuestStatus.Waitting;
                if(quests[i].justTalk)
                quests[i].questStatus=Quest.QuestStatus.Completed;
                
                break;
                
            }
  
         
         
        }

        for (int i = quests.Length - 1; i >= 0; i--)//触发某一事件需要将之前但已经不需要的任务都设置为完成,那如果该完成的任务之前有一个正在进行的任务呢？，不应该，一时间一个人物可以触发的任务应该只有一个，就算如果该任务状态是等待或者完成，那么其后的任务应该本来都是完成状态
        {//那如果是通过singlequest更新的任务呢，那么在singlequest之后，在其之后的任务可能不是完成状态，这个时候也需要更新,那如果是更新的justtalk类型呢，那么这个循环会找到，应该不会有什么额外情况，可是该函数会订阅两种函数，如果是天数更新的话会不会影响呢，比如说有没有存在当前最新任务是等待或者接受的状态
        //然后天数更新，将下一个任务更新为了等待状态呢,这样的情况该怎么处理呢，如果是接受状态的只有日课，日课没有完成的话睡不了觉，目前应该是这种情况，那直接更新好了
            if((quests[i].questStatus==Quest.QuestStatus.Completed||quests[i].questStatus==Quest.QuestStatus.Waitting||quests[i].questStatus==Quest.QuestStatus.Accepted))
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    quests[j].questStatus=Quest.QuestStatus.Completed;
                    quests[j].justTalk=false;
                    //NextQuestUpdateDone(quests[j].questName);
                }
            }

        }
        
    }
    public Quest  findquest(string _questid)
    {
        
        for(int i=0;i<quests.Length;i++)
        {
            if(quests[i].questName==_questid)
            return quests[i];
           
        }
        return null;
    }
}
