using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUpponPlayer : MonoBehaviour
{
    public GameObject talkPosition;
    public string talktargetname;
    // Start is called before the first frame update
    void Start()
    {
       GameEventSystem.instance.onItemCheck+=talktarget;
    }
    private void OnDisable() 
    {
       GameEventSystem.instance.onItemCheck-=talktarget;
    }
    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("DialogueAndPointer")!=null)
        {
        if(DialogueScript.instance.name!=""&&DialogueScript.instance.name!=null)
        {
            if(DialogueScript.instance.name=="Player")
            {
                talkPosition=GameObject.Find("UpponPlayer");
                this.transform.position = Camera.main.WorldToScreenPoint(talkPosition.transform.position);
            }
            else
            {
                 talkPosition=GameObject.Find(DialogueScript.instance.name);
                 this.transform.position = Camera.main.WorldToScreenPoint(talkPosition.transform.position);

            }
           
        }
        else if( talktargetname!=""&&talktargetname!=null&&DialogueScript.instance.name==""&&DialogueScript.instance.name!=null&&GameObject.Find( talktargetname).GetComponent<Questable>())
        {
            if(GameObject.Find( talktargetname).transform.parent.gameObject.CompareTag("NPC"))
            {
                talkPosition=GameObject.Find( talktargetname).transform.parent.gameObject;

            }
            else
            {
                talkPosition=GameObject.Find( talktargetname);
            }
            
            this.transform.position = Camera.main.WorldToScreenPoint(talkPosition.transform.position);
            

        }
        }
    }
    public void talktarget(string _id)
    {
      if(_id!="")
       talktargetname=_id;
       print("第一次按下");
    }
}
