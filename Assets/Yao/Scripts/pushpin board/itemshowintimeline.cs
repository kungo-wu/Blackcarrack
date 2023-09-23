using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class itemshowintimeline : PlayableAsset
{
    public ExposedReference<GameObject> item;
    //public ExposedReference<GameObject> ballcrystal;
    public itemshowintimelinebehaviour template =new itemshowintimelinebehaviour();
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var Playable= ScriptPlayable<itemshowintimelinebehaviour>.Create(graph,template);
        Playable.GetBehaviour().item=item.Resolve(graph.GetResolver());
        //Playable.GetBehaviour().ballcrystal=ballcrystal.Resolve(graph.GetResolver());
        return Playable;
    }
}

public class itemshowintimelinebehaviour : PlayableBehaviour
{
    private PlayableDirector playabledirector;
    public GameObject item;
    //public GameObject ballcrystal;
    public override void OnPlayableCreate(Playable playable)
    {
       playabledirector=playable.GetGraph().GetResolver() as PlayableDirector;
    }
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if(item!=null)
        {
         item.SetActive(true);
        
        
          Debug.Log("播放");
        }
        
        
    }
}  
