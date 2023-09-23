using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneNotice : MonoBehaviour
{
    public GameObject changeSceneNoticeTMP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            if (changeSceneNoticeTMP.activeInHierarchy==false)
            {
                changeSceneNoticeTMP.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (changeSceneNoticeTMP.activeInHierarchy == true)
            {
                changeSceneNoticeTMP.SetActive(false);
            }
        }
    }
}
