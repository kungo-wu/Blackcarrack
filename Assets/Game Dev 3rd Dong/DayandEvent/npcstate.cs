using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcstate : MonoBehaviour
{
    public  bool death;
    public string temporarychange;
    // Start is called before the first frame update
    void Start()
    {
        GameEventSystem.instance.onTemporarychange+=deathtrigger;
    }
    void OnDisable()
    {
        GameEventSystem.instance.onTemporarychange-=deathtrigger;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void deathtrigger(string _id)
    {
        if(_id==temporarychange)
        death=true;
    }
}
