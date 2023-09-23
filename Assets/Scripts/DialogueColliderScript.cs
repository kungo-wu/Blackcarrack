using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueColliderScript : MonoBehaviour
{
    private BoxCollider _collider;

    public GameObject dialogueReminder;
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            dialogueReminder.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            dialogueReminder.SetActive(false);
        }
    }
}
