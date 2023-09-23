using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class tostart: MonoBehaviour
{
    public GameObject button;
    public GameObject loadUI;
    public GameObject Player;
    public Slider slider;
    public Text text;
    public  GameObject faderBackgroundCanvasGroup;
    private CanvasGroup canvasGroup;
    private bool _isPlayerLeaving=false;
    public float fadeDuration = 0.5f;
    float change_Scene_Fade_Timer;
    private void Start() 
    {
        toStart();
    }
    public void toStart()
    {
        StartCoroutine(Load1());
        print("开始");
        
       // StartCoroutine(Loadfirst());
    }
  
    IEnumerator Load()
    {
        //button.SetActive(false);
        Player.SetActive(true);
        loadUI.SetActive(true);
        for (int i = 4; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            print("开始预加载第一次");
            string sceneName = SceneUtility.GetScenePathByBuildIndex(i);
            AsyncOperation loadall =SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive);   
            loadall.allowSceneActivation=false;

           /*while(!loadall.isDone)
         {
            
            if(loadall.progress>=0.9f)
            {
                
                    //loadall.allowSceneActivation=true;
                    print("预加载成功一次");
                
            }
           
         }*/    
          yield return loadall.allowSceneActivation=true;
        }
       
        /* for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string sceneName = SceneUtility.GetScenePathByBuildIndex(i);
            AsyncOperation async = SceneManager.UnloadSceneAsync(sceneName);
            print(sceneName);
        }*/
         //StartCoroutine(UnloadSceneAsync());
            
        StartCoroutine(Loadfirst());
 
    }
    public IEnumerator UnloadSceneAsync()
    {
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string sceneName = SceneUtility.GetScenePathByBuildIndex(i);
            Scene scene = SceneManager.GetSceneByName(sceneName);
            AsyncOperation async = SceneManager.UnloadSceneAsync(scene);
            yield return async;
            print(sceneName);
        }
        StartCoroutine(Loadfirst());
 
    }


    IEnumerator Loadfirst()
    {
        float startTime = Time.time;
       // loadUI.SetActive(true);
        print("成功执行");
        AsyncOperation loadfirst =SceneManager.LoadSceneAsync("deck(first)");
         loadfirst.allowSceneActivation=false;
         LoadScene.Sceneleaving=true;
         while(!loadfirst.isDone)
         {
            print( slider.value);
            slider.value+=Time.deltaTime*0.2f;
            int intValue = (int)(slider.value * 100);   // 将浮点数转换为整数
            text.text = intValue.ToString() + "%";
            if (Time.time - startTime >= 2)
            {
                if(loadfirst.progress>=0.9f&&slider.value>=0.9)
            {
                slider.value=1;
                text.text="按下任意按键";
                if(Input.anyKeyDown)
                {
                    
                    loadfirst.allowSceneActivation=true;
                    DaytoShow.daytoshowtimetoshow=true;
                    bagnoticenotoshow.bagnoticetimetoshow=true;
                    LoadScene.Scenecoming=true;
                    LoadScene.Sceneleaving=false;


                }
            }

            }

            
            yield return null;
         }
    }
    IEnumerator Load1()
{
    //button.SetActive(false);
    Player.SetActive(true);
    loadUI.SetActive(true);

    for (int i = 4; i < SceneManager.sceneCountInBuildSettings; i++)
    {
        string sceneName = SceneUtility.GetScenePathByBuildIndex(i);
        AsyncOperation loadall = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);   
        loadall.allowSceneActivation = false;

        while (!loadall.isDone)
        {
            if (loadall.progress >= 0.9f)
            {
                print("预加载成功一次");
                loadall.allowSceneActivation = true;
            }
            yield return null;
        }

        Scene loadedScene = SceneManager.GetSceneByBuildIndex(i);
        AsyncOperation unload = SceneManager.UnloadSceneAsync(loadedScene);
        while (!unload.isDone)
        {
            yield return null;
        }
    }

    yield return  StartCoroutine(Loadfirst());
}



}
