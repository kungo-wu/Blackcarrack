using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUITest : MonoBehaviour
{
    public CanvasGroup UITest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            if(Input.GetKeyDown(KeyCode.F))
            {

            }
        }
    }
}
