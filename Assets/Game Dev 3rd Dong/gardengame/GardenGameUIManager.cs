using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GardenGameUIManager : MonoBehaviour
{
    public Slider gardenslider;
    public GameObject gardengame;
    public string dayTarget;
    private  static bool one=true;
    private static bool two=true;
    private static bool three=true;
    private static bool four=true;
    void Start()
    {
        
        GameEventSystem.instance.onQTEfinished+=UIchangeincrease;
        GameEventSystem.instance.onQTEloss+=UIchangeminus;
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name=="Garden"&&PlayerEvent.Day==5)
        {
            gardengame.SetActive(true);
            if(one)
            {
                GameEventSystem.instance.Temporarychange("garden");
                one=false;
            }
            
            
        }
        else
        {
            gardengame.SetActive(false);
        }
        if(gardenslider.value>=1f)
        {
            GameEventSystem.instance.onQTEloss-=UIchangeminus;
            if(SceneManager.GetActiveScene().name!="Garden"&&two)
            {
                GameEventSystem.instance.Temporarychange("gardenafter");
                GameObject.Find("chef").GetComponent<npcstate>().death=true;
                two=false;

            }
            if(SceneManager.GetActiveScene().name=="Garden"&&!two&&three)
            {
                GameEventSystem.instance.Temporarychange("gardenback");
                GameObject.Find("chef").GetComponent<npcstate>().death=false;
                three=false;
            }
            //GameEventSystem.instance.Singlequest("chef0502");
            //GameEventSystem.instance.Questupdate();
            if(four)
            {
                 GameEventSystem.instance.Temporarychange("puzzlecomplete");
                 four=false;

            }
           
            GameEventSystem.instance.EventCompleted( dayTarget);
            GameEventSystem.instance.Temporarychange( dayTarget);
        }
    }
    void OnDisable()
    {
         GameEventSystem.instance.onQTEfinished-=UIchangeincrease;
         GameEventSystem.instance.onQTEloss-=UIchangeminus;
    }
    private void UIchangeincrease()
    {
        gardenslider.value+=0.2f;
        print("成功增加");
    }
    private void UIchangeminus()
    {
        gardenslider.value-=0.01f;
        print("成功减小");
        
    }
}
