using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAbnormity : MonoBehaviour
{   public float minWaitTime = 4f;
    public float maxWaitTime = 5f;
    private float waitTime=4f;
    private string ShowAbnormityid;
    private GameObject qteTrigger;
    public GameObject qteTriggerPrefab;
    private bool ShowAbnormitycheck;
    //private bool ShowAbnormitycheck;
    private ItemTrigger itemTrigger;
    public static bool finished;

    void Start()
    {
        itemTrigger = gameObject.GetComponent<ItemTrigger>();
        itemTrigger.enabled=false;
        ShowAbnormityid=gameObject.name;
        if(PlayerEvent.Day==5&&!finished)
        StartCoroutine(RandomCoroutine());
        GameEventSystem.instance.onItemTrigger+=showqte;
        GameEventSystem.instance.onEventCompleted+=targetcomplete;


          
    }
   
    
    private void OnDisable()
    {
        GameEventSystem.instance.onItemTrigger-=showqte;
        GameEventSystem.instance.onEventCompleted-=targetcomplete;

    }

    IEnumerator RandomCoroutine()
    {
        while (true)
        {
            // 生成随机时间间隔
            float waitTime = Random.Range(minWaitTime, maxWaitTime);

            // 等待随机时间
            yield return new WaitForSeconds(waitTime);

            // 调用 MyFunction 函数，并等待返回的协程
            yield return StartCoroutine(showAbnormity());
        }
    }

    IEnumerator showAbnormity()
    {
        // 启用 itemTrigger 组件
        itemTrigger.enabled = true;
        transform.GetChild(1).gameObject.GetComponent<Animator>().enabled=false;
       // transform.GetChild(2).gameObject.SetActive(true);

        // 等待 4 秒
        yield return new WaitForSeconds( waitTime);

        // 禁用 itemTrigger 组件
        itemTrigger.enabled = false;
       // transform.GetChild(1).gameObject.SetActive(true);
        //transform.GetChild(2).gameObject.SetActive(false);
        if(qteTrigger==null)
        {
            GameEventSystem.instance.QTEloss();

        }
        
        print("等待4s结束");
    }
    private void showqte(string _id)
    {
        
       if(ShowAbnormityid==_id&&itemTrigger.enabled == true&&qteTrigger==null)    
       {
           
           print("启动成功");
           qteTrigger = Instantiate( qteTriggerPrefab, transform.position , Quaternion.identity, transform);
           transform.GetChild(1).gameObject.GetComponent<Animator>().enabled=true;
           itemTrigger.enabled = false;
           //transform.GetChild(1).gameObject.SetActive(true);
          // transform.GetChild(2).gameObject.SetActive(false);
       }
    }
    public void targetcomplete(string _id)
    {
        if(_id=="每日任务：打理植物园")
        {
            finished=true;
        }
    }

  

}
    

