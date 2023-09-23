using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
public class basement : MonoBehaviour
{
    public PlayableDirector tl;
    private TimelineUnit helper;
    public GameObject qte;
    public TimelineAsset[] pushpintimeline;
    private bool canshow;
    // Start is called before the first frame update
    void Start()
    {
         tl.stopped += OnTimelineStopped;
        GameEventSystem.instance.onTemporarychange+= basementrepair;
        GameEventSystem.instance.onQTEfinished+= afterqte;
        
        
    }
    private void OnDisable() 
    {
        GameEventSystem.instance.onTemporarychange-= basementrepair;
        GameEventSystem.instance.onQTEfinished-=  afterqte;
    }
    private void Awake() 
    {
        helper = new TimelineUnit();
        helper.Init("basement",tl);//存放制作好的timeline
    }   
    // Update is called once per frame
    void Update()
    {
       
         if(SceneManager.GetActiveScene ().name=="Basement"&&canshow)
            {
                helper.Switch("basement");
                helper.SetBinding("Animation Track", GameObject.Find("merchant"));
                helper.SetBinding("Animation Track (1)", GameObject.Find("servant"));
                helper.SetBinding("Animation Track (2)",GameObject.Find("oldseaman"));
                helper.SetBinding("Animation Track (3)",GameObject.Find("merchant").transform.Find("merchant@Old Man Idle").gameObject);
                helper.SetBinding("Animation Track (4)",GameObject.Find("servant").transform.Find("servant@Old Man Idle").gameObject);
                helper.SetBinding("Animation Track (5)",GameObject.Find("oldseaman").transform.Find("crowseaman@Breathing Idle").gameObject);
                qte=GameObject.Find("qte").transform.GetChild(0).gameObject;
                tl.Play(pushpintimeline[0]);
                qte.SetActive(true);
                canshow=false;
            }
             
    }
    public void basementrepair(string _id)
    {
        if(_id=="basementrepair")
        {
           canshow=true;
           Debug.Log("地下室");
        }
    }
    public void afterqte()
    {
        if(SceneManager.GetActiveScene ().name=="Basement")
        {
            GameEventSystem.instance.Singlequest("02merchanteventafter");
            GameEventSystem.instance.Singlequest("02oldseamanafterevent01");
            GameEventSystem.instance.Questupdate();
            helper.Switch("basementafterqte");
            helper.SetBinding("Animation Track", GameObject.Find("oldseaman"));
            helper.SetBinding("Animation Track (1)", GameObject.Find("oldseaman").transform.Find("crowseaman@Breathing Idle").gameObject);
            tl.Play(pushpintimeline[1]);
            PlayerController.isPlayerInfirst=true;
        }
    }
    private void OnTimelineStopped(PlayableDirector director)
    {
        // 获取当前播放的 TimelineAsset
        TimelineAsset currentTimeline = director.playableAsset as TimelineAsset;
         if (currentTimeline != null && currentTimeline.name=="basementafterqte")
        {
            // 执行特定的逻辑
           
           GameEventSystem.instance.Temporarychange("basementafter");
           PlayerController.isPlayerInfirst=false;
            // 在这里可以执行你的逻辑操作
        }
    }
}
