using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPointerPosition : MonoBehaviour
{
    //Vector3 containerPosition = new Vector3();
    public GameObject Player;
    public GameObject Pointer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player=GameObject.Find("Player");
       
        Pointer.transform.position=Camera.main.WorldToScreenPoint(Player.transform.position);
    }
}
