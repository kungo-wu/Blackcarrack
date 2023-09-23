using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Playerpositionchange : MonoBehaviour
{
    public GameObject leaveposition;
    //private GameObject getinposition;
    public GameObject Player;
    // Start is called before the first frame update
    public void Start()
    {
        if(SceneManager.GetActiveScene ().name!="Start")
        leaveposition= GameObject.FindWithTag(SceneManager.GetActiveScene ().name);
        Player= GameObject.FindWithTag("Player");
        Player.transform.position=new Vector3(leaveposition.transform.position.x,leaveposition.transform.position.y,leaveposition.transform.position.z);
        

        //leaveposition= GameObject.FindWithTag(SceneManager.GetActiveScene ().name);

    }

    // Update is called once per frame
     public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.G)||Input.GetKeyDown(KeyCode.E))
        {
            
           leaveposition.transform.position=new Vector3(Player.transform.position.x,Player.transform.position.y,Player.transform.position.z);

        }
        
    }
    
}
