using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayenermy : MonoBehaviour
{
    public int daycheck;
    public int dayleave;
    private bool one=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerEvent.Day==daycheck&&one)
        {
            for(int i=0;i<transform.childCount;i++)
            transform.GetChild(i).gameObject.SetActive(true);
            one=false;
        }
         if(PlayerEvent.Day==dayleave)
        {
            for(int i=0;i<transform.childCount;i++)
            transform.GetChild(i).gameObject.SetActive(false);
            
        }
    }

}
