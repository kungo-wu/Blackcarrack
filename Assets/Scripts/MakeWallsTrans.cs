using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeWallsTrans : MonoBehaviour
{
    public GameObject[] gameObjects;
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
            foreach (var obj in gameObjects)
                obj.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (var obj in gameObjects)
                obj.SetActive(true);
        }
    }
}
