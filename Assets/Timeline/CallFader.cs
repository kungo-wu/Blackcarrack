using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CallFader : MonoBehaviour
{
    public static CallFader instance;
    public string Scenechange;
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
    
    public float fadeDuration = 0.5f;
    float change_Scene_Fade_Timer;

    public  GameObject faderBackgroundCanvasGroup;
    private CanvasGroup canvasGroup;
    public bool temporarychange;
    public bool temporaryupdate;
    // Start is called before the first frame update
    void Start()
    {
        GameObject parentObj = GameObject.Find("Canvas");
        GameObject bbb = parentObj.transform.Find("Fader").gameObject;
        faderBackgroundCanvasGroup=bbb;
        canvasGroup = faderBackgroundCanvasGroup.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(temporarychange)
        {
            SceneFade();
        }
       
    }
    public  void SceneFade()
    {
        temporaryupdate=false;
        LoadScene.Sceneleaving=true;
        change_Scene_Fade_Timer += Time.deltaTime;
        canvasGroup.alpha =change_Scene_Fade_Timer / fadeDuration;

        if (change_Scene_Fade_Timer > fadeDuration)
        {
             Debug.Log("CALL");
            temporaryupdate=true;
            GameEventSystem.instance.Temporarychange("daychange");
            if(Scenechange!="")
            SceneManager.LoadScene(Scenechange);
            LoadScene.Sceneleaving=false;
            temporarychange=false;
            
            LoadScene.Scenecoming=true;
            Scenechange="";
            change_Scene_Fade_Timer=0f;

        }
        
    }
}
