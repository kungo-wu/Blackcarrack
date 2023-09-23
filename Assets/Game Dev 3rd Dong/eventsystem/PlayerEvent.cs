using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour
{
    public static PlayerEvent instance;
 
    public static int Day=0;
    public int itemAmount;
    public List<Quest> questList=new List<Quest>();
    public Dictionary<string,Quest> questDict=new Dictionary<string,Quest>();
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
        DontDestroyOnLoad(gameObject);
        
    }

    private void Start()
    {
        if( QuestUIManager.instance!=null)
        QuestUIManager.instance.UpdateQuestList();
    }

    
}
