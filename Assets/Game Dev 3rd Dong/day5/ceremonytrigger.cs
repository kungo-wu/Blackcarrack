using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceremonytrigger : MonoBehaviour
{
    public GameObject chooseui;
    // Start is called before the first frame update
    void Start()
    {
        chooseui=GameObject.Find("Confirm").transform.GetChild(4).gameObject;
        GameEventSystem.instance.onItemTrigger+=ceremonychoose;
    }
    void OnDisable()
    {
        GameEventSystem.instance.onItemTrigger-=ceremonychoose;
    }
    // Update is called once per frame
    void Update()
    {
        if(confirmwindow05.confirm)
        {
            GameEventSystem.instance.Temporarychange("ceremony");
            ItemTrigger.notinteract=false;
            GetComponent<ItemTrigger>().enabled=false;
            EndingCGScript.isWorshipStopped=true;
            confirmwindow05.confirm=false;
        }
        if(confirmwindow05.cancel)
        {
            CallFader.instance.temporarychange=true;
            CallFader.instance.Scenechange="Ending";
            ItemTrigger.notinteract=false;
            GetComponent<ItemTrigger>().enabled=false;
            confirmwindow05.cancel=false;
            
        }
    }
    public void  ceremonychoose(string _id)
    {
        if(_id==gameObject.name)
        {
            chooseui.SetActive(true);
            ItemTrigger.notinteract=true;
           

        }
    }
}
