using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class firstevent : MonoBehaviour
{
    private bool _isPlayerLeaving=false;
    public string toScene;

    public float fadeDuration = 0.5f;
    float change_Scene_Fade_Timer;

    public  GameObject faderBackgroundCanvasGroup;
    private CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        
        PlayerController.isPlayerInfirst=true;
        GameEventSystem.instance.onDialogueFinish+=firsttoevent;
        GameObject parentObj = GameObject.Find("Canvas");
        GameObject bbb = parentObj.transform.Find("Fader").gameObject;
        faderBackgroundCanvasGroup=bbb;
        canvasGroup = faderBackgroundCanvasGroup.GetComponent<CanvasGroup>();
        StartCoroutine(first());
    }
    void OnEnable()
    {
         //GameEventSystem.instance.onDialogueFinish+=firsttoevent;
    }
    private void OnDisable()
    {
       
        GameEventSystem.instance.onDialogueFinish-=firsttoevent;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_isPlayerLeaving)
        { 
            
             LoadScene.Sceneleaving=true;
            change_Scene_Fade_Timer += Time.deltaTime;
            canvasGroup.alpha =change_Scene_Fade_Timer / fadeDuration;

        if (change_Scene_Fade_Timer > fadeDuration)
        {
             SceneManager.LoadScene(toScene);
             _isPlayerLeaving = false;
             LoadScene.Sceneleaving=false;
             PlayerController.isPlayerInfirst=false;
             PlayerEvent.Day++;
             LoadScene.Scenecoming=true;
             GameEventSystem.instance.Scenechange();
        }
        }
    }
    
    public void firsttoevent()
    {
        print("开始跳转");
        
            
           _isPlayerLeaving = true;

        

    }
    private IEnumerator first()
    {
        yield return new WaitForSeconds(0.5f); // 延迟0.5秒

        // 在这里写下你想要延迟执行的函数的代码
        GameEventSystem.instance.Temporarychange("eventatfirst");
    }

}
