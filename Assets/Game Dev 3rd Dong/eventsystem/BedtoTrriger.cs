using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedtoTrriger : MonoBehaviour
{
    private string Bedid;
    public float fadeDuration = 0.5f;
    float change_Scene_Fade_Timer;

    public  GameObject faderBackgroundCanvasGroup;
    private CanvasGroup canvasGroup;
    private bool temporarychange;
    private float currentTime=0f;
    private void Start()
    {
        Bedid=gameObject.name;
        GameObject parentObj = GameObject.Find("Canvas");
        GameObject bbb = parentObj.transform.Find("Fader").gameObject;
        faderBackgroundCanvasGroup=bbb;
        canvasGroup = faderBackgroundCanvasGroup.GetComponent<CanvasGroup>();
        GameEventSystem.instance.onItemTrigger+=DayIncrease;
    }
     private void OnDisable()
    {
        GameEventSystem.instance.onItemTrigger-=DayIncrease;
        
    }
    public void Update()
    {
        currentTime += Time.deltaTime;
        if(temporarychange)
        {
            SceneFade();
        }
    }
    public void DayIncrease(string _id)
    {
        if(currentTime < 2f)
        return;       
        if(Bedid==_id)
        {
             currentTime=0f;
             temporarychange=true;
             PlayerEvent.Day+=1;
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
    
}
