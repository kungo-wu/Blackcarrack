using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private bool _isPlayerLeaving=false;
    public bool specialgetin;
    private bool cangetin;
    public int daycheck;
    
    public string toScene;

    public float fadeDuration = 0.5f;
    float change_Scene_Fade_Timer;

    public  GameObject faderBackgroundCanvasGroup;
    private CanvasGroup canvasGroup;
    private float currentTime=0f;
    public string temporarychange;

    // Start is called before the first frame update
    void Start()
    {
        
        GameObject parentObj = GameObject.Find("Canvas");
        GameObject bbb = parentObj.transform.Find("Fader").gameObject;
        faderBackgroundCanvasGroup=bbb;
        canvasGroup = faderBackgroundCanvasGroup.GetComponent<CanvasGroup>();
        GameEventSystem.instance.onTemporarychange+= TemporaryScene;
    }
    void OnDisable()
    {
         GameEventSystem.instance.onTemporarychange-= TemporaryScene;

    }


    // Update is called once per frame
    void Update()
    {
         currentTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.G))
        {
           
            if(currentTime < 0.5f)
            return;
           _isPlayerLeaving = true;
            GameEventSystem.instance.Temporarychange("opendoor");
            currentTime=0f;

        }

        if (_isPlayerLeaving&&daycheck==0)
        { 
            
            SceneFade();
            
            
        }
        else if(_isPlayerLeaving&&daycheck<=PlayerEvent.Day&&!specialgetin)
        {
            
            SceneFade();
            
        }
        else if(_isPlayerLeaving&&daycheck<=PlayerEvent.Day&&specialgetin&&cangetin)
        {
            
            SceneFade();
            
        }
    }

    void SceneFade()
    {
        
        LoadScene.Sceneleaving=true;
        change_Scene_Fade_Timer += Time.deltaTime;
        canvasGroup.alpha =change_Scene_Fade_Timer / fadeDuration;

        if (change_Scene_Fade_Timer > fadeDuration)
        {
             GameEventSystem.instance.Scenechange();
             SceneManager.LoadScene(toScene);
             
             _isPlayerLeaving = false;
             LoadScene.Sceneleaving=false;
             change_Scene_Fade_Timer =0f;
             LoadScene.Scenecoming=true;
             if(temporarychange!="")
             {
                GameEventSystem.instance.Temporarychange(temporarychange);
             }
             gameObject.SetActive(false);
        }
        
    }
    void TemporaryScene(string _scene)
    {
        if(toScene==_scene)
        {
            cangetin=true;
        }
       
    }

}
