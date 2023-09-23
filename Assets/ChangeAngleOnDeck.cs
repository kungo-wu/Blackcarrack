using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAngleOnDeck : MonoBehaviour
{
    public GameObject vcam1;
    public GameObject vcam3;
    [SerializeField]
    float camAngle;

    private void Start()
    {
        vcam1 = GameObject.Find("ChangeCameraRotation01").transform.Find("CM vcam1").gameObject;
        vcam3 = GameObject.Find("ChangeCameraRotation01").transform.Find("CM vcam3").gameObject;
        camAngle= 45f;
    }

    
    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player"&&camAngle==315f)
        {
            vcam1.SetActive(true);
            vcam3.SetActive(false);
            camAngle = 45f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag=="Player"&&camAngle==45f)
        {
            Debug.Log("进入");
            vcam1.SetActive(false);
            vcam3.SetActive(true);
            camAngle = 315f;
        }
    }
}
