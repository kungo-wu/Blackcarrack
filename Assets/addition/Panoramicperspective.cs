using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Panoramicperspective : MonoBehaviour
{
    public string temporaryreceive;
    public GameObject leavepositionondeck;
    public GameObject changetarget;
    private bool changecanmera;
    public GameObject camera;
    private bool Onmast;
    // Start is called before the first frame update
    void Start()
    {
        GameEventSystem.instance.onTemporarychange+=changeposition;
    }
    void OnDisable()
    {
        GameEventSystem.instance.onTemporarychange-=changeposition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Onmast&&SceneManager.GetActiveScene().name=="Deck(Ship)")
        {
             if(Input.GetKeyDown(KeyCode.Space))
            {
                  Debug.Log("按下空格");
                 camera.SetActive(!camera.activeInHierarchy);    
                 

            }

        }
        if(changecanmera&&SceneManager.GetActiveScene().name=="Deck(Ship)")
        {
            //camera.SetActive(true);
           
           
            leavepositionondeck.SetActive(true);
            changetarget.SetActive(false);
            changecanmera=false;
        }
        else if(SceneManager.GetActiveScene().name!="Deck(Ship)")
        {
            Onmast=false;
            camera.SetActive(false);
        }
    }
    public void changeposition(string _id)
    {
        if(_id==temporaryreceive)
        {
            leavepositionondeck.SetActive(false);
            changetarget.SetActive(true);
            Onmast=true;
            changecanmera=true;
        }
    }
}
