using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notice : MonoBehaviour
{
    private ItemTrigger itemTrigger;
    public string temporarycheck;
    // Start is called before the first frame update
    void Start()
    {
        
        itemTrigger=GetComponent<ItemTrigger>();
        GameEventSystem.instance.onTemporarychange+=noticeshow;
         itemTrigger.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void noticeshow(string _id)
    {
        if(_id==temporarycheck)
        itemTrigger.enabled=true;

    }
}
