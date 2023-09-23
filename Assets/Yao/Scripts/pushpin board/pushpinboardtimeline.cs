using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class pushpinboardtimeline: MonoBehaviour
{
    private string temporaryid;
    public string temporarycheck;

    public string timelinename;
    private bool thistodo;
    private bool hasplay;
    private static bool isballbreak;
    [SerializeField]
    public PlayableDirector tl;
    public TimelineAsset[] pushpintimeline;

    private GameObject astrologer;


    private TimelineUnit helper;
    // Start is called before the first frame update
    void Start()
    {   

        
        temporaryid=gameObject.name;
        tl.stopped += OnTimelineStopped;
        GameEventSystem.instance.onItemTrigger+=pushpintemporary;
        GameEventSystem.instance.onTemporarychange+=ballbreak;
        astrologer=GameObject.Find("astrologer");
        helper.Switch("ball break");
        helper.SetBinding("Cinemachine Track", Camera.main.gameObject);
        helper.SetBinding("astrologer ball break", GameObject.Find("astrologer"));
        helper.SetBinding("Activation Track",  GameObject.Find("astrologer"));
        if(PlayerEvent.Day==1)
        {
            GetComponent<BoxCollider>().enabled=true;
        }
        else
        {
            GetComponent<BoxCollider>().enabled=false;
        }

    }
    private void Awake() 
    {
        helper = new TimelineUnit();
        helper.Init("pushpin",tl);//存放制作好的timeline
        
    }
    private void OnDisable() 
    {
        GameEventSystem.instance.onItemTrigger-=pushpintemporary;
        GameEventSystem.instance.onTemporarychange-=ballbreak;
    
    }
    private IEnumerator first()
    {
        yield return new WaitForSeconds(0.5f); // 延迟0.5秒

        // 在这里写下你想要延迟执行的函数的代码
        GameEventSystem.instance.Temporarychange("pushpin");
    }

    // Update is called once per frame
   public void pushpintemporary(string _id)
    {
        if(temporaryid==_id)
        {
            //CallFader.instance.temporarychange=true;
            StartCoroutine(first());
            thistodo=true;
            
            
        }

    }
    private void Update() 
    {
        if(thistodo&&!hasplay )
        {
            PlayerController.isPlayerInfirst=true;
            tl.Play(pushpintimeline[0]);
            //SceneManager.LoadScene("Telescope");
            thistodo=false;
            
           // CallFader.instance.temporaryupdate=false;
             

        }
        if(Input.GetKeyDown(KeyCode.G)&&hasplay)
             {
                tl.Play(pushpintimeline[1]);
                
                
             }   
             if(isballbreak)
             {
                //GameObject.Find("NPCpositonchange pushpinfail").GetComponent<SeceneDayChange>().temporaryreceive="pushpinfail";
                //GameObject.Find("NPCpositonchange02astrologer").GetComponent<SeceneDayChange>().temporaryreceive="";
                GameObject.Find("astrologer").GetComponent<npcstate>().death=false;
             }
             if(!isballbreak)
             {
                //GameObject.Find("NPCpositonchange02astrologer").GetComponent<SeceneDayChange>().temporaryreceive="pushpinfail";
                GameObject.Find("astrologer").GetComponent<npcstate>().death=true;

             }
    }
private void OnTimelineStopped(PlayableDirector director)
    {
        // 获取当前播放的 TimelineAsset
        TimelineAsset currentTimeline = director.playableAsset as TimelineAsset;
         if (currentTimeline != null && currentTimeline.name=="pushpin boardTimeline")
        {
            // 执行特定的逻辑
           
           hasplay=true;
            // 在这里可以执行你的逻辑操作
        }

        // 检查当前播放的 Timeline 是否在 timelineAssets 数组中
        if (currentTimeline != null && currentTimeline.name=="pushpin boardTimelineback"&&!isballbreak)
        {
            // 执行特定的逻辑
           
           PlayerController.isPlayerInfirst=false;
           hasplay=false;
            // 在这里可以执行你的逻辑操作
        }
        if(isballbreak&&currentTimeline != null && currentTimeline.name=="pushpin boardTimelineback")
        {
            Debug.Log("特定的 Timeline 播放结束");
            tl.Play(pushpintimeline[2]);
            GameEventSystem.instance.Singlequest("astrologer star puzzle seuccess");
            GameEventSystem.instance.Questupdate();
            PlayerController.isPlayerInfirst=false;
            hasplay=false;
        }
    }
    public void ballbreak(string _id)
    {
        if(_id=="ballbreak")
        {
            isballbreak=true;
            tl.Play(pushpintimeline[1]);
        }
    }
    










}
