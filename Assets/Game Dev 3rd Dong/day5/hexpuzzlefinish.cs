using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hexpuzzlefinish : MonoBehaviour
{
    public string index;
    public static List<GameObject> hexs=new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        index=gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.name==("hex"+index))
        {
             if(!hexs.Contains(other.gameObject))
             {
                hexs.Add(other.gameObject);
                Debug.Log(hexs.Count);
             }
        }
    }
}
