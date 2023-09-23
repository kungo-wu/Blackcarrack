using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baguianimator : MonoBehaviour
{
    public AnimationCurve showcurve;
    public AnimationCurve hidecurve;
    public float animationspeed;
    public GameObject gird;
    //public GameObject quest;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
         StartCoroutine(showquest());
    }
    void OnDisable()
    {
        //StartCoroutine(hidequest());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator showquest()
    {
        float timer=0;
        while(timer<=1)
        {
            gird.transform.localScale= new Vector3(1f,1f,01f)*showcurve.Evaluate(timer);
            timer+=Time.deltaTime*animationspeed;
            yield return null;
        }
    }
    public IEnumerator hidequest()
    {
        Debug.Log("缩回");
        float timer=0;
        while(timer<=1)
        {
            gird.transform.localScale= new Vector3(1f,1f,01f)*hidecurve.Evaluate(timer);
            timer+=Time.deltaTime*animationspeed;
            yield return null;
        }
        gameObject.SetActive(false);
    }
    public IEnumerator changequest()
    {
        float timer=0;
        while(timer<=1)
        {
            gird.transform.localScale=Vector3.one*hidecurve.Evaluate(timer);
            timer+=Time.deltaTime*animationspeed;
            yield return null;
        }
       
    }
    public void show()
    {
        StartCoroutine(showquest());
    }
    public void hide()
    {
        StartCoroutine(hidequest());
    }
    public void change()
    {
        StartCoroutine(changequest());
    }
}
