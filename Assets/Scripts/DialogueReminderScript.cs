using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueReminderScript : MonoBehaviour
{
    public GameObject dialogue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            dialogue.SetActive(true);
        }

        if (dialogue.activeInHierarchy==true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    
}
