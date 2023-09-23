using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class utilitypuzzle : MonoBehaviour
{
    public GameObject cm1;
    public GameObject cm2;
    private string puzzleid;
    // Start is called before the first frame update
    void Start()
    {
        puzzleid=gameObject.name;
        GameEventSystem.instance.onItemTrigger+=openpuzzle;
    }
    private void OnDisable() 
    {
         GameEventSystem.instance.onItemTrigger-=openpuzzle;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerEvent.Day!=4)
        {
            //GetComponent<ItemTrigger>().enabled=false;
        }
        else
        {
             //GetComponent<ItemTrigger>().enabled=true;
        }
    }
    public void openpuzzle(string _id)
    {
        if(_id==puzzleid)
        {
            StartCoroutine(first());
        cm1.SetActive(!cm1.activeInHierarchy);
        cm2.SetActive(!cm2.activeInHierarchy);
        PlayerController.isPlayerInfirst=! PlayerController.isPlayerInfirst;
        }
        
      
    }
    private IEnumerator first()
    {
        yield return new WaitForSeconds(0.5f); // 延迟0.5秒

        // 在这里写下你想要延迟执行的函数的代码
        GameEventSystem.instance.Temporarychange("utilitypuzzle");
    }
}
