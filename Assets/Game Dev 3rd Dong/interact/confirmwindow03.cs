using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class confirmwindow04 : MonoBehaviour
{
    public static bool confirm;
    public static bool cancel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buttonconfirm()
    {
        confirm=true;
         GetComponent<confirmanimation>().hide();
        ItemTrigger.notinteract=false;
    }
     public void buttoncancel()
    {
        cancel=true;
         GetComponent<confirmanimation>().hide();
        ItemTrigger.notinteract=false;
    }
      
}
