using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areatrigger : MonoBehaviour
{
    public bool isadsorption;
   public List<GameObject> books = new List<GameObject>();

    private int _index=0;
    private GameObject booklast;
    public Vector3 bookposition;
    public  bool one;
    public string Tagetname;
    private  static bool corouting;
    

    
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(book.name);
        if(books.Count!=0)
        {
        if(books[books.Count-1]!=null&&isadsorption&&!books[books.Count-1].GetComponent<Cooperation>().isdrag)
        {
            if(one)
            {
                if(books[books.Count-1]==booklast)
                {
                if(books.Count>1)
                {
                    if( books[books.Count-1].GetComponent<Cooperation>().index>books[books.Count-2].GetComponent<Cooperation>().index)
                    {
                       Debug.Log("执行成功");
                       books[books.Count-1].transform.position=books[books.Count-1].GetComponent<Cooperation>().startposition;
                       return;
                    }

                }
                books[books.Count-1].GetComponent<Rigidbody>().velocity=Vector3.zero;
                books[books.Count-1].transform.position=gameObject.transform.position;
                Debug.Log("执行一次");
                StartCoroutine(DelayedKinematic());
                one=false;

                }
                
                
            }
            for(int i=0;i<books.Count-1;i++)
            {
            //Debug.Log("循环");
            books[i].GetComponent<Cooperation>().canmove=false;
            }
            
            
           
        
        }
      
        
        if(books[books.Count-1]!=null&&books[books.Count-1].GetComponent<Cooperation>().isdrag)
        {
            booklast=books[books.Count-1];
            one=true;
        }
        if(books.Count==6&&Tagetname!="")
        {
           
               if(books[books.Count-1].GetComponent<Rigidbody>().isKinematic==true)
               {
                GameEventSystem.instance.Temporarychange("puzzlecomplete");
                GameEventSystem.instance.EventCompleted(Tagetname);
                GameEventSystem.instance.Temporarychange(Tagetname);
               }
            
        }
        }
    }
    
    
   private IEnumerator DelayedKinematic()
{
    yield return new WaitForSeconds(0.1f); // 延迟0.5秒

    while (true)
    {
        if (books[books.Count-1]!= null && books[books.Count-1].GetComponent<Rigidbody>().velocity == Vector3.zero&&books[books.Count-1].transform.position!=gameObject.transform.position)
        {
           
            books[books.Count-1].GetComponent<Rigidbody>().isKinematic = true;
            break; // 完成协程，退出循环
        }

        yield return null; // 等待下一帧继续判断
    }

    
}
    private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("book"))
        {
            if(!books.Contains(other.gameObject))
            books.Add(other.gameObject);
            //Debug.Log("成功");
            if(!isadsorption)
            {
                
                isadsorption=true;

            }
            
            
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("book"))
        {
            books.RemoveAt(books.Count - 1);
            //Debug.Log("成功");
            isadsorption=false;           
            books[books.Count-1].GetComponent<Cooperation>().canmove=true;
      
            
        }
    }
    public void check()
    {
        if(books.Count>1)
        {
            if( books[books.Count-1].GetComponent<Cooperation>().index>books[books.Count-2].GetComponent<Cooperation>().index)
            {
                Debug.Log("执行成功");
                books[books.Count-1].transform.position=books[books.Count-1].GetComponent<Cooperation>().startposition;
                return;
            }

        }
        
    }
}
