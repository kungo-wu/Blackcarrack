using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
public class ceremonydirector : MonoBehaviour
{
     private string temporaryid;
     public string temporarycheck;
     [SerializeField]
    public PlayableDirector tl;
    public TimelineAsset[] pushpintimeline;

    private GameObject astrologer;


    private TimelineUnit helper;
    public static bool one=true;
    public GameObject cm1;
    public GameObject cm2;
    public GameObject cm3;
    public GameObject dialogue;
    public bool finish01;
    public bool finish02;
    public static bool justone=true;
    public static int endingindex;
    private void Awake() 
    {
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        temporaryid=gameObject.name;
        tl.stopped += OnTimelineStopped;
        GameObject parentObj = GameObject.Find("Dialogue");
        GameObject bbb = parentObj.transform.Find("DialogueAndPointer").gameObject;
        dialogue=bbb;
        
        //GameEventSystem.instance.onTemporarychange+=ceremonyplay;
         //GameEventSystem.instance.onQTEfinished+=dialoguesecond;
         StartCoroutine(first());
        //GameEventSystem.instance.onQTEfinished+=aftertomato;
    }
    private IEnumerator first()
    {
        yield return new WaitForSeconds(0.5f); // 延迟0.5秒

        // 在这里写下你想要延迟执行的函数的代码
        GameEventSystem.instance.Temporarychange("ceremonynotice");
    }
     void OnDisable()
    {
        GameEventSystem.instance.onTemporarychange-=ceremonyplay;
        GameEventSystem.instance.onQTEfinished-=dialoguesecond;
        GameEventSystem.instance.onQTEfinished-=ending;
    }
    void OnEnable()
    {
        helper = new TimelineUnit();
        helper.Init("ceremony",tl);//存放制作好的timeline
        GameEventSystem.instance.onTemporarychange+=ceremonyplay;
        GameEventSystem.instance.onQTEfinished+=dialoguesecond;
        GameEventSystem.instance.onQTEfinished+=ending;

    }

    // Update is called once per frame
    void Update()
    {
        dialoguefirst();
        //dialoguesecondafter();
    }
    public void ceremonyplay(string _id)
    {
        if(_id==temporarycheck&&one)
        {
            tl=GetComponent<PlayableDirector>();
            helper = new TimelineUnit();
            helper.Init("ceremony",tl);//存放制作好的timeline
            GameObject.Find("oldseaman").GetComponent<CapsuleCollider>().enabled=true;
            GameObject.Find("oldseaman").GetComponent<BoxCollider>().enabled=true;
            GameObject.Find("oldseaman").transform.GetChild(1).GetComponent<CapsuleCollider>().enabled=true;
           // GameObject.Find("oldseaman").transform.GetChild(1).GetComponent<BoxCollider>().enabled=false;
            Debug.Log("开始");
            helper.Switch("ceremonydirectorTimeline");
            helper.SetBinding("Animation Track", GameObject.Find("oldseaman"));
            helper.SetBinding("Cinemachine Track", Camera.main.gameObject);
            helper.SetBinding("Activation Track", GameObject.Find("CM vcam1").gameObject);
            helper.SetBinding("Activation Track (1)", GameObject.Find("ceremonydirector").transform.Find("CM vcam2").gameObject);
            helper.SetBinding("Animation Track (1)", GameObject.Find("oldseaman").transform.Find("crowseaman@Breathing Idle").gameObject);
            tl.Play(pushpintimeline[0]);
            one=false;
            
        }

    }
    private void OnTimelineStopped(PlayableDirector director)
    {
        // 获取当前播放的 TimelineAsset
        TimelineAsset currentTimeline = director.playableAsset as TimelineAsset;
         if (currentTimeline != null && currentTimeline.name=="ceremonydirectorTimeline")
        {
            // 执行特定的逻辑
           finish01=true;
            // 在这里可以执行你的逻辑操作s
        }
         if (currentTimeline != null && currentTimeline.name=="ceremony02")
        {
            // 执行特定的逻辑
           finish02=true;
           cm3.SetActive(false);
           cm1.SetActive(true);
            // 在这里可以执行你的逻辑操作s
        }

    }
    public void dialoguefirst()
    {
        if(finish01&&!dialogue.activeInHierarchy)
        {
            cm2.SetActive(true);
            cm2.SetActive(false);
            cm1.SetActive(true);
            GameEventSystem.instance.Temporarychange("ceremonyafter");
            finish01=false;
        }
    }
    public void dialoguesecond()
    {
        ItemTrigger.notinteract=false;
        if(justone&&PlayerEvent.Day==5&&SceneManager.GetActiveScene().name=="SecretRoomWithEye")
        {
             bool Fkeyone=true;
              if(Fkeyone)
                {    Debug.Log("不够");

                     GameEventSystem.Keybd_event(70, 0, 1, 0);
                     Input.ResetInputAxes();
                     Fkeyone = false;

                }
            helper.Switch("ceremony02");
            helper.SetBinding("Animation Track", GameObject.Find("oldseaman"));
            //helper.SetBinding("Cinemachine Track", Camera.main.gameObject);
            helper.SetBinding("Activation Track", GameObject.Find("ceremonydirector").transform.Find("CM vcam3").gameObject);
            helper.SetBinding("Animation Track (1)", GameObject.Find("oldseaman").transform.Find("crowseaman@Breathing Idle").gameObject);
            
            helper.SetBinding("Activation Track (1)", GameObject.Find("CM vcam1"));
            tl.Play(pushpintimeline[1]);
            
            justone=false;
        }
           
    }
    public void dialoguesecondafter()
    {
        if(finish02&&!dialogue.activeInHierarchy)
        {
            
            cm3.SetActive(false);
            cm1.SetActive(true);
            //GameEventSystem.instance.Temporarychange("ceremonyafter");
            finish02=false;
        }
    }
    public void ending()
    {
        
        endingindex++;

        if(finish02&&!dialogue.activeInHierarchy&&endingindex==4)
        {
            
            
            CallFader.instance.temporarychange=true;
            CallFader.instance.Scenechange="Ending";
            //GameEventSystem.instance.Temporarychange("ceremonyafter");
            finish02=false;
        }
    }
}
