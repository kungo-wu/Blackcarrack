using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
public class gardendirector : MonoBehaviour
{
     private string temporaryid;
     public string temporarycheck;
     [SerializeField]
    public PlayableDirector tl;
    public TimelineAsset[] pushpintimeline;

    private GameObject astrologer;


    private TimelineUnit helper;
    public static bool one=true;
    public GameObject tomato;
    public GameObject qte;
    public static bool back;
    private void Awake() 
    {
       
        
    }
    // Start is called before the first frame update
    void Start()
    {
        temporaryid=gameObject.name;
        
        //GameEventSystem.instance.onTemporarychange+=gardenplay;
        //GameEventSystem.instance.onQTEfinished+=aftertomato;
        
    }
    void OnDisable()
    {
        GameEventSystem.instance.onTemporarychange-=gardenplay;
        GameEventSystem.instance.onQTEfinished-=aftertomato;
    }
    void OnEnable()
    {
        
        GameEventSystem.instance.onTemporarychange+=gardenplay;
        GameEventSystem.instance.onQTEfinished+=aftertomato;

    }
    // Update is called once per frame
    void Update()
    {
    
    }
    public void gardenplay(string _id)
    {
        if(_id==temporarycheck)
        {
            tl=gameObject.GetComponent<PlayableDirector>();
            helper = new TimelineUnit();
            helper.Init("garden",tl);//存放制作好的timeline
            helper.Switch("gardendirectorTimeline");
        helper.SetBinding("Animation Track", GameObject.Find("chef"));
        helper.SetBinding("Activation Track", GameObject.Find("whole tomato").transform.Find("monster tomato ani2 (4)").gameObject);
       // helper.SetBinding("Animation Track (1)", GameObject.Find("whole tomato").transform.Find("monster tomato ani2 (4)").gameObject);
        helper.SetBinding("Activation Track (1)", GameObject.Find("gardendirector").transform.Find("CM vcam2").gameObject);
        helper.SetBinding("Activation Track (2)", GameObject.Find("whole tomato").transform.Find("tomato qte").gameObject);
        helper.SetBinding("Activation Track (3)", GameObject.Find("CM vcam1"));
            tl.Play(pushpintimeline[0]);
            ItemTrigger.notinteract=true;
            back=true;
        }

    }
    public void aftertomato()
    {
        
        
            if(SceneManager.GetActiveScene().name=="Garden"&&back)
        {
            tomato.GetComponent<Animator>().SetTrigger("death");
            GameEventSystem.instance.Singlequest("chef0502");
            GameEventSystem.instance.Questupdate();
            ItemTrigger.notinteract=false;
            back=false;
        }

        
        
    }
}
