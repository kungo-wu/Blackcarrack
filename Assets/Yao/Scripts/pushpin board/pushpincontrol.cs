using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushpincontrol : MonoBehaviour
{
    public static Transform starttransform;
    public static Transform endtransform;
    public static bool isclick;
    public Material linematerial;
    public GameObject line;
    public GameObject linepromt;
    public List<GameObject> lines=new List<GameObject>();

    public static int getindex;
    public List<int> indexs=new List<int>();
    public bool success;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isclick&&!success)
        {
            indexs.Add(getindex);
            if(indexs.Count>=2&&indexs[indexs.Count-1]==indexs[indexs.Count-2]&&indexs[indexs.Count-1]!=0)
            {
                indexs.RemoveAt(indexs.Count-1);
            }
            if(lines.Count<1)
            {
               starttransform=endtransform;
              
            }
            linepromt= Instantiate(line, transform.position, Quaternion.identity, transform);          
            lines.Add(linepromt);    
            linepromt.GetComponent<line>().A=starttransform;
            linepromt.GetComponent<line>().B=endtransform;
            starttransform=endtransform;
            endtransform=null;
            //linepromt=null;
            getindex=0;
            isclick=false;
        }
        if(indexs.Count==5&&!success)
        {
            for(int i=0;i<5;i++)
            {
                if(indexs[i]!=i+1)
                return;
            }
            GameEventSystem.instance.Temporarychange("puzzlecomplete");
            GameEventSystem.instance.Temporarychange("ballbreak");
            success=true;
        }
         if(!success&&Input.GetKeyDown(KeyCode.G))
         {
             Debug.Log("退出");
             for(int i=0;i<lines.Count;i++)
             {
                Destroy(lines[i].gameObject);

             }
             lines.Clear();
             indexs.Clear();
         }
         
    }
    
}
