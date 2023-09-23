using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guideedit : MonoBehaviour
{
    [TextArea(1,6)]
    public string[] lines;
    public string temporarychange;
    public GameObject guidedialogue;
    public static bool one=true;
    // Start is called before the first frame update
    void Start()
    {
        guidedialogue=GameObject.Find("Guide").transform.Find("guide").gameObject;
        GameEventSystem.instance.onTemporarychange+=guidereload;
    }
    void OnDisable()
    {
         GameEventSystem.instance.onTemporarychange-=guidereload;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void guidereload(string _id)
    {
        
        if(_id==temporarychange)
        {
            Debug.Log("传输");
            guidedialogue.SetActive(true);
            guide.instance.LoadDialogue(lines);
            
            one=false;

        }
        
        
        
    }
}
