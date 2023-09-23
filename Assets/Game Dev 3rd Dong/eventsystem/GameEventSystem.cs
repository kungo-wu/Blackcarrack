using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class GameEventSystem : MonoBehaviour//声明游戏内事件系统
{

    public static GameEventSystem instance;
    private void Awake() 
    {
        if(instance==null)
        {
            instance =this;
        }
        else
        {
            if(instance!=this)
            {
                Destroy(gameObject);
            }
        }
        //DontDestroyOnLoad(gameObject);
        
    }
    [DllImport("user32.dll", EntryPoint = "keybd_event")]
    public static extern void Keybd_event(byte bvk, byte bScan, int dwFlags, int dwExtraInfo);

    


    
    public event Action<string> onItemTrigger;//当靠近物体且与其发生交互时
    public event Action<string> onItemCheck;//当靠近物体时
    public event Action onDialogueFinish;//任意对话完成时
    public event Action<string,string> onDelegateQuest;//开始分派任务时
    public event Action<string> onDialogueCheck;//对话对象核对时
    public event Action<string> onDialogueStart;//对话开始时
    public event Action<string> onGatheringUpdate;//收集类物品更新时
    public event Action<string> onTargetCompleted;//任务完成时
    public event Action<string> onEventCompleted;//事件型任务完成时
    public event Action<string,string> onJustTalkFinished;//更新Justtalk类型时（此类型需要在对话一开始就更新其状态，而其他类型任务则在对话结束时更新状态）
    public event Action onDayChange;//更新日期时
    public event Action onQTEfinished;//qte完成时
    public event Action onQTEloss;//花园游戏中未在四秒内完成
    public event Action onScenechange;
    public event Action<string> onSinglequest;
    public event Action<string> onTemporarychange;
    public event Action onQuestupdate;
    public void ItemTrigger(string _id)
    {
        if(onItemTrigger!=null)
        onItemTrigger(_id);
        //print("trigger成功");
        
    }
    public void ItemCheck(string _id)
    {
        if(onItemCheck!=null)
        onItemCheck(_id);
        
    }
    public void DialogueFinish()
    {
        if(onDialogueFinish!=null)
        onDialogueFinish();
        //print("DialogueFinish事件触发");
    }
     public void DialogueStart(string _id)
    {
        if(onDialogueStart!=null)
        onDialogueStart(_id);
        
    }
     public void DelegateQuest(string _id ,string _questid)
    {
        
        if(onDelegateQuest!=null)
        {
           // print("1");
            onDelegateQuest( _id ,_questid);
            //print("事件内部");

        }              
    }
     public void JustTalkFinished(string _id ,string _questid)
    {
        
        if(onJustTalkFinished!=null)
        {
           // print("1");
            onJustTalkFinished( _id ,_questid);
            //print("事件内部");

        }              
    }
    public void DialogueCheck(string _id)
    {
        if(onDialogueCheck!=null)
        onDialogueCheck(_id);
        
    }
    public void GatheringUpdate(string _id)
    {
        if(onGatheringUpdate!=null)
        onGatheringUpdate( _id);
        
    }
     public void TargetCompleted(string _id)
    {
        if(onTargetCompleted!=null)
        onTargetCompleted( _id);
        
    }
    public void EventCompleted(string _id)
    {
        if(onEventCompleted!=null)
        onEventCompleted( _id);
        
    }
    public void DayChange()
    {
        if(onDayChange!=null)
        onDayChange();
       
    }
   public void QTEfinished()
    {
        if(onQTEfinished!=null)
        onQTEfinished();
        print("QTE事件触发");
    }
    public void QTEloss()
    {
        if(onQTEloss!=null)
        onQTEloss();
        
    }
    public void Scenechange()
    {
        if(onScenechange!=null)
        onScenechange();
        
    }
       public void Singlequest(string _id)
    {
        if(onSinglequest!=null)
        onSinglequest(_id);
       
        
    }
     public void Temporarychange(string _id)
    {
        if(onTemporarychange!=null)
        onTemporarychange(_id);
       
        
    }
        public void Questupdate()
    {
        if(onQuestupdate!=null)
        onQuestupdate();
        
    }
}
