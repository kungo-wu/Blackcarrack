using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confirmsleep : MonoBehaviour
{
    public GameObject Sleep;
    public GameObject Event;
    public GameObject textfirst;
    public GameObject textthen;
    public float fadeDuration = 0.5f;
    float change_Scene_Fade_Timer;

    public  GameObject faderBackgroundCanvasGroup;
    private CanvasGroup canvasGroup;
    private bool temporarychange;
    public GameObject daychange;
    private bool then;
    // Start is called before the first frame update
    void Start()
    {
        Sleep=GameObject.Find("Sleep").transform.Find("sleep").gameObject;
        Event=GameObject.Find("Event");
        textfirst=Sleep.transform.Find("confirmtosleep").gameObject;
        textthen=Sleep.transform.Find("cannotsleep").gameObject;
        GameObject parentObj = GameObject.Find("Canvas");
        GameObject bbb = parentObj.transform.Find("Fader").gameObject;
        faderBackgroundCanvasGroup=bbb;
        canvasGroup = faderBackgroundCanvasGroup.GetComponent<CanvasGroup>();
        GameEventSystem.instance.onItemTrigger+=sleeptoshow;
    }
    void OnDisable()
    {
        GameEventSystem.instance.onItemTrigger-=sleeptoshow;
    }
    // Update is called once per frame
    void Update()
    {
        if(temporarychange)
        {
            SceneFade();
        }
    }
    public void sleeptoshow(string _id)
    {
        if(_id=="bedtrigger")
        {
            Sleep.SetActive(true);
        }
    }
    public void DayIncrease()
    {
        
              
        if(PlayerEvent.Day<5)
        {
             CallFader.instance.fadeDuration=1.5f;
             CallFader.instance.temporarychange=true;
             PlayerEvent.Day+=1;
             daychange.SetActive(true);
             GameEventSystem.instance.DayChange();
             QuestUIManager.instance.UpdateQuestList();

        }
       
    }
     void SceneFade()
    {
        
        change_Scene_Fade_Timer += Time.deltaTime;
        canvasGroup.alpha =change_Scene_Fade_Timer / fadeDuration;

        if (change_Scene_Fade_Timer > fadeDuration)
        {
            change_Scene_Fade_Timer =0f;
             temporarychange=false;

             LoadScene.Scenecoming=true;
        }
        
    }
    public void confirm()
    {
        print("点击成功");
        if(PlayerEvent.instance.questList.Count!=0)
        {
            if(PlayerEvent.instance.questList[PlayerEvent.Day-1].questStatus==Quest.QuestStatus.Completed)
        {
            DayIncrease();
            Sleep.GetComponent<confirmanimation>().hide();
        }
        else if(then)
        {
            textfirst.SetActive(true);
            textthen.SetActive(false);
            then=false;
            Sleep.GetComponent<confirmanimation>().hide();
        }
        else
        {
            textfirst.SetActive(false);
            textthen.SetActive(true);
            then=true;

        }

        }
        if(PlayerEvent.instance.questList.Count==0)
        {
            if(then)
            {
            textfirst.SetActive(true);
            textthen.SetActive(false);
            then=false;
            Sleep.GetComponent<confirmanimation>().hide();
            }
            textfirst.SetActive(false);
            textthen.SetActive(true);
            then=true;
            
        }
        
        

    }
     public void cancel()
     {
            textfirst.SetActive(true);
            textthen.SetActive(false);
            then=false;
            Sleep.GetComponent<confirmanimation>().hide();

     }
}
