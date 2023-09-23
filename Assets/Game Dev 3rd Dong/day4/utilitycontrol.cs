using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[SerializeField]
public class utilitycontrol : MonoBehaviour
{
    public static utilitycontrol instance;
    public int indexcheck;
    private bool isadsorption;
    public GameObject item;
    public static int successamount;
    private static bool  one=true;
    
    public  List< GameObject>  items=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name!="UtilityRoom")
        {
             successamount=0;
        }
        if(item!=null&&isadsorption&&!item.GetComponent<cooperationforutility>().isdrag&&!item.GetComponent<Rigidbody>().isKinematic)
        {
            item.GetComponent<Rigidbody>().velocity=Vector3.zero;
            item.transform.position=gameObject.transform.position;
            if(item.GetComponent<cooperationforutility>().index==indexcheck)
            {
                if(!items.Contains(item))
                {
                    items.Add(item);
                    successamount++;
                    Debug.Log(successamount);
                }
                
                
            }
        }
        if(successamount>=4&&PlayerEvent.Day==4&&one)
        {
            GameEventSystem.instance.Temporarychange("puzzlecomplete");
            GameEventSystem.instance.EventCompleted("每日任务：清理杂物间");
            GameEventSystem.instance.Temporarychange("每日任务：清理杂物间");
            GameEventSystem.instance.Temporarychange("day04event");
            GameEventSystem.instance.Singlequest("firstmate0402");
            GameEventSystem.instance.Questupdate();
            successamount=0;
            one=false;
            
        }
        
    }
     private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("ultilitypuzzle")&&item==null)
        {
            item=other.gameObject;
            //Debug.Log("成功");
            if(!isadsorption)
            {
                
                isadsorption=true;

            }
           
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("ultilitypuzzle")&&item!=null)
        {
             if(item.GetComponent<cooperationforutility>().index==indexcheck)
            {
                Debug.Log("remove");
                if(items.Contains(item))
                {
                   items.Remove(item);
                   successamount--;
                }
                
            } 
            
            item=null;
            //Debug.Log("成功");
            isadsorption=false;           
            
           
            
        }
    }
    public static void rightclick(int _index)
    {
         if(instance.item.GetComponent<cooperationforutility>().index==instance.indexcheck&&_index==instance.indexcheck)
         {
            successamount--;
            Debug.Log(successamount);
         }
    }
}
