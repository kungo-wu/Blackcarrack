using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class repair : MonoBehaviour
{
    private Questable questable;
    public item hammer;
    public item nail;
    public item board;
    private bool one=true;
    [SerializeField]
    public static int targetamount;
    private bool hascompleted;
    private GameObject firstmate;
    private static bool justone=true;
    private  bool two=true;
    public GameObject dialogue;
    private void Start() 
    {
        questable=gameObject.GetComponent<Questable>();
        firstmate=GameObject.Find("firstmate");
        GameObject parentObj = GameObject.Find("Dialogue");
        GameObject bbb = parentObj.transform.Find("DialogueAndPointer").gameObject;
        dialogue=bbb;

    }
    private IEnumerator first()
    {
        yield return new WaitForSeconds(0.5f); // 延迟0.5秒

        // 在这里写下你想要延迟执行的函数的代码
        GameEventSystem.instance.Temporarychange("day2repair");
    }
    private void Update() 
    {
          if(PlayerEvent.Day==2&&justone&&SceneManager.GetActiveScene().name=="LowerCorridor")
        {
            StartCoroutine(first());
            //gameObject.transform.GetChild(0).gameObject.SetActive(true);
            justone=false;
            
        }
        if(PlayerEvent.Day==2&&two&&SceneManager.GetActiveScene().name=="LowerCorridor")
        {
            
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            two=false;
            
        }
        if(targetamount>=3)
        {
            GameEventSystem.instance.Temporarychange("puzzlecomplete");
            GameEventSystem.instance.EventCompleted("每日任务：修补船舱");
            GameEventSystem.instance.Temporarychange("每日任务：修补船舱");
            //firstmate.GetComponent<Questable>().quests[1].questStatus=Quest.QuestStatus.Completed;
            //firstmate.GetComponent<Questable>().quests[1]
            
            Debug.Log(targetamount);
            StartCoroutine(DelayedFunction(1.0f));
            

            
           
            targetamount=0;
            
        }
        if(questable!=null&&!questable.quests[1].justTalk)
        {
            if(!hascompleted&&hammer.itemamount>=1&&nail.itemamount>=2&&board.itemamount>=1)
            {
                questable.quests[1].questStatus=Quest.QuestStatus.Completed;
                questable.quests[2].questStatus=Quest.QuestStatus.Completed;
                questable.quests[2].justTalk=false;
                nail.itemamount=nail.itemamount-2;
                board.itemamount--;
                InventoryManageritem.Refreshitem();
                repair.targetamount++;
                transform.GetChild(0).gameObject.SetActive(false);
                hascompleted=true;
                Debug.Log(targetamount);

                
            }
            else if( !hascompleted&&questable.quests[2].questStatus==Quest.QuestStatus.Completed&&!dialogue.activeInHierarchy)
            {
                
                if(one)
                {    Debug.Log("不够");

                     GameEventSystem.Keybd_event(69, 0, 1, 0);
                     Input.ResetInputAxes();
                     one = false;

                }
                 if(!questable.quests[2].justTalk&&!questable.quests[1].justTalk)
           {
            questable.quests[2].justTalk=true;
            questable.quests[2].questStatus=Quest.QuestStatus.Banned;
            questable.quests[1].justTalk=true;
            one=true;
           }
                //questable.quests[1].justTalk=true;
  

            }
            
           

        }
       
    }
    IEnumerator DelayedFunction(float delayTime)
{
    yield return new WaitForSeconds(delayTime);

    // 在延迟后执行的代码
               bool justone=true;
              if(justone)
                {    Debug.Log("不够");

                     GameEventSystem.Keybd_event(69, 0, 1, 0);
                     Input.ResetInputAxes();
                     justone = false;

                }
            CallFader.instance.temporarychange=true;
            CallFader.instance.Scenechange="Deck(Ship)";
            GameEventSystem.instance.Temporarychange("day02finish");
            GameEventSystem.instance.Singlequest("merchant and servant 02daytarger");
            GameEventSystem.instance.Singlequest("firstmate02 yes");
            GameEventSystem.instance.Questupdate();
}


  
}
