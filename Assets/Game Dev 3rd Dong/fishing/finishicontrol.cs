using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
public class finishicontrol : MonoBehaviour
{
    public Image image;
    public float speed=0.3f;
    public float raise=0.1f;
    public static bool isfinish=true;   
    public static int Day2fishamount=0;
    [Header("该日课对应任务系统的名称")]
    public string dayTarget;
    public Slider fishing;
    public item[] fish;
    public GameObject[] fishprefeb;
    public item thisfish;
    public GameObject thisfishprefab;
    public GameObject thisfishprefabpromot;
    private int index;
    public Inventory playerInventory;
    public PlayableDirector tl;
    
     private TimelineUnit helper;
     public TimelineAsset[] pushpintimeline;
        private void Awake() 
    {

       //存放制作好的timeline
        
    }
    // Start is called before the first frame update
    void Start()
    {
         tl.stopped += OnTimelineStopped;
          
    }

    // Update is called once per frame
    void Update()
    {
        fishmotion();
      
        
    }
   void OnEnable()
   {
    tl=GameObject.Find("fishing test").GetComponent<PlayableDirector>(); 
    helper = new TimelineUnit();
    helper.Init("fish",tl);

   }
    
    void fishmotion()
    {
        if(image.fillAmount<1 )
        {
        
            if(fishingselect.isselectsucess==true)
        {
            
            image.fillAmount+=raise*Time.deltaTime;
           
            
         
        }
        
            if(image.fillAmount>=0&&image.fillAmount<1)
        {
            image.fillAmount-=speed*Time.deltaTime;
        }
         
        }
        else
        {
            
            fishing.value=0;
            image.fillAmount=0;
            GameEventSystem.instance.Temporarychange("fishcomplete");
            GameObject.Find("Player").GetComponent<Animator>().ResetTrigger("Fishing");
            index=Random.Range(0,fish.Length);
            thisfish=fish[index];
            thisfishprefab=fishprefeb[index];
            thisfishprefabpromot= Instantiate(thisfishprefab, GameObject.Find("CM vcam1").transform.Find("fishprefab").gameObject.transform);
            GameEventSystem.instance.Temporarychange(""+index);
            print("成功完成");
             helper.Switch("fishing testTimeline");
             helper.SetBinding("Animation Track", thisfishprefabpromot);
             helper.SetBinding("Activation Track", thisfishprefabpromot);
             tl.Play(pushpintimeline[0]);
            
            /*if(!playerInventory.itemList.Contains(thisfish))
            {
            //  playerInventory .itemList .Add (thisItem);
            //InventoryManager.CreatNewItem(thisItem);
            for (int i=0;i<playerInventory.itemList.Count;i++)
            {
                if(playerInventory.itemList[i]==null)
                {
                    playerInventory.itemList[i]=thisfish;
                    thisfish.itemamount = 1;
                    break;
                }
            }
            }
             else
            {
            thisfish.itemamount += 1;
            }
            InventoryManageritem.Refreshitem();
            InventoryManagernote.Refreshitem();*/
            thisfish=null;
            thisfishprefab=null;
            index=0;
            //Destroy(thisfishprefabpromt);
        if(PlayerEvent.Day==3)                                                
        {            
            print("钓鱼成功") ;
            Day2fishamount+=1;
            print(Day2fishamount);
           
            if(Day2fishamount>=3)
        {
            GameEventSystem.instance.Temporarychange("puzzlecomplete");
            GameEventSystem.instance.Temporarychange("day03finish");
            GameEventSystem.instance.Singlequest("寻找船舱线索");
            GameEventSystem.instance.Singlequest("captain06");
            GameEventSystem.instance.Questupdate();
            GameEventSystem.instance.EventCompleted( dayTarget);
            GameEventSystem.instance.Temporarychange(dayTarget);
 ;       }
        }
         isfinish=true;

        } 
        
    
    
           
            
    
        
}
    private void OnTimelineStopped(PlayableDirector director)
    {
        // 获取当前播放的 TimelineAsset
        TimelineAsset currentTimeline = director.playableAsset as TimelineAsset;
        if (currentTimeline != null && currentTimeline.name=="fishing testTimeline")
        {
            // 执行特定的逻辑
           
           Destroy(thisfishprefabpromot);
           PlayerController.isPlayerInfirst=false;
            // 在这里可以执行你的逻辑操作
        }
    }
}
