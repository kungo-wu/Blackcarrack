using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushpinsingle : MonoBehaviour
{
    public int correctindex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("点击");
            pushpincontrol.endtransform=transform;
            pushpincontrol.isclick=true;
            pushpincontrol.getindex=correctindex;
        }
    }
}
