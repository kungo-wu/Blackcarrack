using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class QuestUIManager : MonoBehaviour
{
    public static QuestUIManager instance;
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
    public List<GameObject> quests=new List<GameObject>();
    private GameObject nowquest;
    public GameObject questArray;//-760 200
    public GameObject questPrefab;
    public Sprite imagetocheckAccepted;
    public Sprite imagetocheckFinished;
    public Image image;
    private static bool isQuestUIiopen;
    public bool one=true;
    public List<Quest> finishedquests=new List<Quest>();


    private void Start()
    {
        if(PlayerEvent.instance.questList.Count!=0)
        {
            for(int i=0;i<PlayerEvent.instance.questList.Count;i++)
        {
            //instance. quests[i].SetActive(false);
        }
        
        image.color=new Color( image.color.r, image.color.g, image.color.b,0f);

        }
        
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            isQuestUIiopen=!isQuestUIiopen;
            one=true;

        }
        if(isQuestUIiopen&&PlayerEvent.instance.questList.Count!=0&&one)
        {
            for(int i=0;i<quests.Count;i++)
        {
            if(instance. quests.Count!=0)
            instance. quests[i].GetComponent<questuianimator>().show();
        }
            one=false;
            //image.color=new Color( image.color.r, image.color.g, image.color.b,1f);;
        }
       else if(!isQuestUIiopen&&PlayerEvent.instance.questList.Count!=0&&PlayerEvent.instance.questList!=null&&one)
        {
           for(int i=0;i<quests.Count;i++)
        {
            if(instance. quests.Count!=0)
            instance. quests[i].GetComponent<questuianimator>().hide();
        }
            one=false;
            //image.color=new Color( image.color.r, image.color.g, image.color.b,0f);
 
        }
        
    }
    public void UpdateQuestList()
    {
        for (int i=0;i<instance.questArray.transform.childCount;i++)
      {
         
         Destroy(instance.questArray.transform.GetChild(i).gameObject);
         instance.quests.Clear();
      }
        for(int i=0;i<PlayerEvent.instance.questList.Count;i++)
        {
                
                if(PlayerEvent.instance.questList[i].questStatus==Quest.QuestStatus.Accepted)
                {
                    Debug.Log("1");
                    isQuestUIiopen=true;
                    nowquest= Instantiate(instance.questPrefab,instance.questArray.transform);
                    instance.quests.Add(nowquest);
                    nowquest.transform.SetParent(instance.questArray.transform);
                    nowquest.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text=""+PlayerEvent.instance.questList[i].questName;
                    //finishedquests.Add(PlayerEvent.instance.questList[i]);
                    nowquest.transform.GetChild(2).GetComponent<Image>().sprite=imagetocheckAccepted;//此后如果任务完成后，需要做进一步的效果  

                }
                else if(!finishedquests.Contains(PlayerEvent.instance.questList[i])&&PlayerEvent.instance.questList[i].questStatus==Quest.QuestStatus.Completed)
                {
                    Debug.Log("2");
                 
                    isQuestUIiopen=true;
                    finishedquests.Add(PlayerEvent.instance.questList[i]);
                    nowquest= Instantiate(instance.questPrefab,instance.questArray.transform);
                    instance.quests.Add(nowquest);
                    nowquest.transform.SetParent(instance.questArray.transform);
                    nowquest.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text=""+PlayerEvent.instance.questList[i].questName;
                    //finishedquests.Add(PlayerEvent.instance.questList[i]);
                    Debug.Log(PlayerEvent.instance.questList.Count);
                    nowquest.transform.GetChild(2).GetComponent<Image>().sprite=imagetocheckFinished;//此后如果任务完成后，需要做进一步的效果
                      
                    //Destroy(instance.quests[i]);-
                    nowquest.GetComponent<questuianimator>().destroy();                
                    Debug.Log(PlayerEvent.instance.questList[i].questName);
                    instance.quests.Remove(nowquest);
                    
                    
                    //instance.quests.RemoveAll(item => item == null);
                }
                else if(finishedquests.Contains(PlayerEvent.instance.questList[i])&&PlayerEvent.instance.questList[i].questStatus==Quest.QuestStatus.Completed)
                {
                    Debug.Log("3");
                    isQuestUIiopen=true;
                    
                    
                }

        }
                
                

            
            
        
    }
    
}
