using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class talktimelinecontrol : PlayableAsset
{
    
    public talktimelinecontrolbehaviour template =new talktimelinecontrolbehaviour();
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var Playable= ScriptPlayable<talktimelinecontrolbehaviour>.Create(graph,template);
        
        return Playable;
    }
}

public class talktimelinecontrolbehaviour : PlayableBehaviour
{
    private PlayableDirector playabledirector;
   
    public override void OnPlayableCreate(Playable playable)
    {
       playabledirector=playable.GetGraph().GetResolver() as PlayableDirector;
    }
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        bool justone=true;
              if(justone)
                {    Debug.Log("不够");

                     GameEventSystem.Keybd_event(70, 0, 1, 0);
                     Input.ResetInputAxes();
                     justone = false;

                }
    
        
    }
}  
