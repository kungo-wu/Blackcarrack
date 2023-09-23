using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintpuzzletrigger : MonoBehaviour
{
    private GameObject chooseui;
    private string name;
    public GameObject cm1;
    public GameObject cm2;
    public GameObject key;
    public bool thisone;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        chooseui=GameObject.Find("Confirm").transform.GetChild(3).gameObject;
        GameEventSystem.instance.onItemTrigger+=pupzzletrigger;
        cm1=GameObject.Find("CM vcam1");
        cm2=GameObject.Find("paint cm").transform.Find("CM vcam2").gameObject;
        key=GameObject.Find("key2");
        door=GameObject.Find("secretdoor");
    }
    void OnDisable()
    {
        GameEventSystem.instance.onItemTrigger-=pupzzletrigger;
    }
    // Update is called once per frame
    void Update()
    {
        if(thisone&&Input.GetKeyDown(KeyCode.E)&&key.GetComponent<itemonworld>().enabled)
        {
            cm1.SetActive(true);
            cm2.SetActive(false);
        }
        if(confirmwindow04.confirm&&name==gameObject.name)
        {
            
            StartCoroutine(MoveObject());
            name=null;
            if(thisone)
            {
                key.GetComponent<itemonworld>().enabled=true;
                key.GetComponent<BoxCollider>().enabled=true;
                door.transform.GetChild(0).gameObject.SetActive(true);
                 GameEventSystem.instance.Temporarychange("puzzlecomplete");
            }
            if(!thisone)
            {
                CallFader.instance.temporarychange=true;
                CallFader.instance.Scenechange="LowerCorridor";
            }

            confirmwindow04.confirm=false;

            
        }
        if(confirmwindow04.cancel&&name==gameObject.name)
        {
            cm1.SetActive(true);
            cm2.SetActive(false);
            name=null;
            confirmwindow04.cancel=false;
        }
    }
    public void pupzzletrigger(string _id)
    {
        if(_id==gameObject.name&&PlayerEvent.Day==5)
        {
            cm2.transform.position=gameObject.transform.parent.GetChild(1).transform.position;
            cm2.transform.rotation=gameObject.transform.parent.GetChild(1).transform.rotation;
            name=_id;
            chooseui.SetActive(true);
            ItemTrigger.notinteract=true;
            cm1.SetActive(false);
            cm2.SetActive(true);
        }
        
    }
    public IEnumerator RotateObject()
    {
        float t = 0f; // 插值参数

        Quaternion startRotation =  gameObject.transform.parent.transform .rotation; // 起始旋转角度
        Quaternion targetRotation = Quaternion.Euler(0f, 90f, 0f); // 目标旋转角度

        while (t < 1f)
        {
            // 根据插值参数 t 获取当前旋转角度
            Quaternion newRotation = Quaternion.Lerp(startRotation, targetRotation, t);

            // 更新物体的旋转角度
            gameObject.transform.parent.transform .rotation= newRotation;

            // 增加插值参数 t
            t += Time.deltaTime * 1f;

            yield return null;
        }

        // 完成旋转
       
    }
    private System.Collections.IEnumerator MoveObject()
    {
        float t = 0f; // 插值参数
        Vector3 startPosition = gameObject.transform.parent.transform.position;
        Vector3 targetPosition = startPosition + new Vector3(0f, 1.4f, 0f);
        while (t < 1f)
        {
            // 根据插值参数 t 获取当前位置
            Vector3 newPosition = Vector3.Lerp(startPosition, targetPosition, t);

            // 更新物体的位置
            gameObject.transform.parent.transform.position = newPosition;

            // 增加插值参数 t
            t += Time.deltaTime * 1f;

            yield return null;
        }
        if(!thisone)
        {
            cm1.SetActive(true);
            cm2.SetActive(false);
 
        }
        
        
        // 完成平移
        
    }
}








    

