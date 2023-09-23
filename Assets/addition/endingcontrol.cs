using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerEvent.Day==5)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
