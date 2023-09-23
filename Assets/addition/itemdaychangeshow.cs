using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemdaychangeshow : MonoBehaviour
{
    public string temporarychange;
    public GameObject item;
    public bool notshow;
    // Start is called before the first frame update
    void Start()
    {
        GameEventSystem.instance.onTemporarychange+=itemchangeshow;
    }
    void OnDisable()
    {
        GameEventSystem.instance.onTemporarychange-=itemchangeshow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void itemchangeshow(string _id)
    {
        if(_id==temporarychange)
        {
            if(!notshow)
            item.SetActive(true);
            if(notshow)
            item.SetActive(false);
        }

    }
}
