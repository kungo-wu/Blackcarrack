using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openbag : MonoBehaviour
{
    public GameObject myitembag;
    public GameObject mynotebag;
    public GameObject bagnotice;
    public GameObject Fade;
    bool isopen;
   
    // Start is called before the first frame update
    void Start()
    {
        
        Fade=GameObject.Find("Canvas").transform.Find("Fader").gameObject;
        GameObject parentObj = GameObject.Find("Bag");
        GameObject bbb = parentObj.transform.Find("item bag ").gameObject;
        myitembag = bbb ;
        mynotebag=parentObj.transform.Find("note bag").gameObject;
        bagnotice=parentObj.transform.Find("bagnotice").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Openmybag();
    }
    void Openmybag()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            GameEventSystem.instance.Temporarychange("openbag");
            isopen=!isopen ;
            if( isopen)
            {
                myitembag.SetActive(true);
                myitembag.GetComponent<baguianimator>().show();
            }
            else if(!isopen)
            {
                
                myitembag.GetComponent<baguianimator>().hide();
                Debug.Log("关闭");

            }
           
            if( isopen)
            {
                mynotebag.SetActive(true);
                mynotebag.GetComponent<baguianimator>().show();
            }
            else if(!isopen)
            {
                mynotebag.GetComponent<baguianimator>().hide();

            }
            
            Fade.SetActive(!isopen);
            bagnotice.SetActive(!isopen);
            Cursor.lockState = CursorLockMode.None;
            InventoryManageritem.Refreshitem();
        }
    }
    public void keydowntrigger()
    {
       
        if(Input.GetKeyDown(KeyCode.F))
        {
         
          print("66");
        }
        
    }

}
