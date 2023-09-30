using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class hexpuzzletrigger : MonoBehaviour
{
    public GameObject cm1;
    public GameObject cm2;
    private string temporaryid;
    public string[] temporarychange;
    public GameObject doorsecret;
    public GameObject doorthis;
    public static bool canopen;
    private bool one=true;
    private bool two=true;
    // Start is called before the first frame update
    void Start()
    {
        temporaryid=gameObject.name;
        GameEventSystem.instance.onItemTrigger+=hexpuzzle;
        GameEventSystem.instance.onItemTrigger+=hexpuzzlecheck;
        cm1.SetActive(true);
        cm2.SetActive(false);
        doorsecret=GameObject.Find("ToSecretWithoutEye").transform.GetChild(0).gameObject;
        //GetComponent<BoxCollider>().enabled=false;
    }
    private void OnDisable() 
    {
        GameEventSystem.instance.onItemTrigger-=hexpuzzle;
        GameEventSystem.instance.onItemTrigger-=hexpuzzlecheck;
    
    }

    // Update is called once per frame
    void Update()
    {
        if(canopen&&!GetComponent<BoxCollider>().enabled)
        {
            GetComponent<BoxCollider>().enabled=true;
        }
        if(GameObject.Find("firstmate").GetComponent<npcstate>().death==true&&two)
        {
            GetComponent<BoxCollider>().enabled=true;
            two=false;
        }
        if(hexpuzzlefinish.hexs.Count>=7&&one)
        {
            
            cm1.SetActive(!cm1.activeInHierarchy);
            cm2.SetActive(!cm2.activeInHierarchy);
            Camera.main.orthographic=true;
            PlayerController.isPlayerInfirst=! PlayerController.isPlayerInfirst;
            doorsecret.SetActive(true);
            doorthis.SetActive(true);
            gameObject.GetComponent<ItemTrigger>().enabled=false;
            GameEventSystem.instance.Temporarychange("puzzlecomplete");
            one=false;
            
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
    public void hexpuzzle(string _id)
    {
        if(temporaryid==_id)
        {
            Camera.main.orthographic=false;
            cm1.SetActive(!cm1.activeInHierarchy);
            cm2.SetActive(!cm2.activeInHierarchy);
            doorthis.SetActive(false);
            PlayerController.isPlayerInfirst=! PlayerController.isPlayerInfirst;
            GameEventSystem.instance.Temporarychange("hexpuzzle");
            
        }

    }
    public void hexpuzzlecheck(string _id)
    {
        for(int i=0;i<temporarychange.Length;i++)
        {
            if(_id==temporarychange[i])
            {
                GetComponent<BoxCollider>().enabled=true;
                break;
            }
        }
    }

}
