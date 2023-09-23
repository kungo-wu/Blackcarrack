using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour
{
    public Transform A=null;
    public Transform B=null;
    public LineRenderer linesingle;
    public bool canshow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(A!=null&&B!=null)
        {
            linesingle.positionCount=2;
            linesingle.SetPosition(0,A.position);
            linesingle.SetPosition(1,B.position);
        }
    }
}
