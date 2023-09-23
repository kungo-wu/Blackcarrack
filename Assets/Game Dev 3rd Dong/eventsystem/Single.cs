using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Single : MonoBehaviour
{
    public static Single instance;
    public List<string> gameobject = new List<string>();
    public static List<GameObject> gameobjects = new List<GameObject>();
    public string objectname;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);

    }
    void Start()
    {
        SingleUpdate();
        //StartCoroutine(LoadAllScenes());
        //Application.LoadLevelAdditiveAsync("Kitchen");
        //Application.LoadLevelAdditiveAsync("CaptainRoom");
    }

    IEnumerator LoadAllScenes()
    {
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string sceneName = SceneUtility.GetScenePathByBuildIndex(i);
            yield return SceneManager.LoadSceneAsync(sceneName);

        }

        // 预加载完成后，可以执行一些要求所有场景都加载完的操作，例如初始化游戏管理器等等
        Application.LoadLevelAdditiveAsync("CaptainRoom");
    }


    void SingleUpdate()
    {
        GameObject[] npcObjs = GameObject.FindGameObjectsWithTag("NPC");
        foreach (GameObject obj in npcObjs)                                //每次场景开始遍历寻找符合tag的物件，当记录表为空时，直接将物件“单例化”，随后将该物件记录在记录表中,如果记录表不为空且现物件不在表中，就将该物件单例化且为空
        {

            if (gameobject != null && !gameobject.Contains(obj.name))//由于场景更新，此物非彼物；
            {


                gameobjects.Add(obj);
                objectname = obj.name;
                gameobject.Add(obj.name);
            }

            else if (gameobject == null)
            {

                gameobjects.Add(obj);
                gameobject.Add(obj.name);

            }
        }
    }
}


