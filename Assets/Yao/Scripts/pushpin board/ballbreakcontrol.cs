using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ballbreakcontrol : PlayableAsset
{
    public ExposedReference<GameObject> ball;
    public ExposedReference<GameObject> ballcrystal;
    public ballbreakcontrolbehaviour template =new ballbreakcontrolbehaviour();
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var Playable= ScriptPlayable<ballbreakcontrolbehaviour>.Create(graph,template);
        Playable.GetBehaviour().ball=ball.Resolve(graph.GetResolver());
        Playable.GetBehaviour().ballcrystal=ballcrystal.Resolve(graph.GetResolver());
        return Playable;
    }
}

public class ballbreakcontrolbehaviour : PlayableBehaviour
{
    private PlayableDirector playabledirector;
    public GameObject ball;
    public GameObject ballcrystal;
    public override void OnPlayableCreate(Playable playable)
    {
       playabledirector=playable.GetGraph().GetResolver() as PlayableDirector;
    }
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if(ball!=null&&ballcrystal!=null)
        {
            for(int i=0;i<ball.transform.childCount;i++)
        {
            ball.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic=false;

        }
        
        for(int i=0;i<ballcrystal.transform.childCount;i++)
        {
            ballcrystal.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic=false;

        } 
          Debug.Log("播放");
        }
        
        
    }
}  
