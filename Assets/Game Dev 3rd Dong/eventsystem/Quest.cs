using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Quest
{
    public enum QuestType {Gathering,Talk,Reach,Event};
    public enum QuestStatus{Banned,Waitting,Accepted,Completed}
    [TextArea(1,6)]
    public string[] questlines;
    public string questName;
    public QuestType questType;
    [Header("除Event（保持默认）类型任务流程初始第一个请设置为Waitting，否则任何有前置任务的请设置为Banned")]
    public QuestStatus questStatus;
    [Header("此任务完成后需要触发的下个任务,可为空")]
    public string nextquestName;
    [Header("选择Event类型请设置所在天数")]
    public int DaytoCheck;
    [Header("选择Event类型是否自动检测开启")]
    public bool EventAuto;   
    [Header("Talk类型不作为需完成任务，仅对话")]
    public bool justTalk;
    
    [Header("为Gathering类型任务要求物品")]
    public item itemTarget;
    [Header("为Gathering类型任务要求数量")]
    public int requireAmount;
    
    
    
    
}
