using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
public class deck02firsttimeline : MonoBehaviour
{
    public PlayableDirector tl;
    private TimelineUnit helper;
    
    public TimelineAsset[] pushpintimeline;
    private bool canshow;
    private static bool one=true;
    void Start()
    {
         tl.stopped += OnTimelineStopped;
      
        
        
    }
    private void OnDisable() 
    {
        
    }
     private void Awake() 
    {
        helper = new TimelineUnit();
        helper.Init("deck",tl);//存放制作好的timeline
    }   
    public void Update()
    {
        
        if(SceneManager.GetActiveScene ().name=="Deck(Ship)"&&PlayerEvent.Day==2&&one)
        {
            GameEventSystem.instance.Singlequest("02oldseaman01");
            GameEventSystem.instance.Questupdate();
            helper.Switch("02deckfirst");
            helper.SetBinding("Cinemachine Track", Camera.main.gameObject);
            helper.SetBinding("Animation Track", GameObject.Find("oldseaman"));
            helper.SetBinding("Animation Track (1)", GameObject.Find("oldseaman").transform.Find("crowseaman@Breathing Idle").gameObject);
            tl.Play(pushpintimeline[0]);
            PlayerController.isPlayerInfirst=true;
            one=false;

        }

    }
    private void OnTimelineStopped(PlayableDirector director)
    {
         TimelineAsset currentTimeline = director.playableAsset as TimelineAsset;
         if (currentTimeline != null && currentTimeline.name=="02deckfirst")
         {
            PlayerController.isPlayerInfirst=false;
            GameEventSystem.instance.Temporarychange("02deckfirstoldseaman");
         }
    }
}
