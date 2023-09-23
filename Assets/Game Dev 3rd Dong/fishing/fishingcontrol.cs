using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fishingcontrol : MonoBehaviour
{
    public Slider fishing;
    public GameObject fish;
    public float speed=0.3f;
    public float raise=0.1f;
    public static float value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        progressclick();
        value=fishing.value;
        fish.SetActive(!finishicontrol.isfinish);
         
        
    }
    void progressclick()
    {
        
        
        
          if(Input.GetMouseButtonDown(0))
        {
            
            fishing.value+= raise;
           
            
         
        }
        
           
        
            fishing.value-=speed*Time.deltaTime;
        

    }
}
