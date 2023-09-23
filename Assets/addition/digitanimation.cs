using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class digitanimation : MonoBehaviour
{
    public AnimationCurve showcurve;
    public AnimationCurve hidecurve;
    public float animationspeed;
    public GameObject digit;
    public GameObject daychange;
    //public GameObject quest;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
        GameEventSystem.instance.onTemporarychange+=showatfirst;
    }
    void OnDisable()
    {
        GameEventSystem.instance.onTemporarychange-=showatfirst;
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
            digit.transform.localScale= new Vector3(1f,1f,01f)*showcurve.Evaluate(timer);
            timer+=Time.deltaTime*animationspeed;
            yield return null;
        }
        StartCoroutine(changequest());
    }
    public IEnumerator showquestagain()
    {
        float timer=0;
        while(timer<=1)
        {
            digit.transform.localScale= new Vector3(1f,1f,01f)*showcurve.Evaluate(timer);
            timer+=Time.deltaTime*animationspeed;
            yield return null;
        }
        
        CallFader.instance.temporarychange=true;
        CallFader.instance.fadeDuration=0.5f;
        gameObject.SetActive(false);
    }
    public IEnumerator hidequest()
    {
        Debug.Log("缩回");
        float timer=0;
        while(timer<=1)
        {
            digit.transform.localScale= new Vector3(1f,1f,01f)*hidecurve.Evaluate(timer);
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
            digit.transform.localScale=Vector3.one*hidecurve.Evaluate(timer);
            timer+=Time.deltaTime*animationspeed;
            yield return null;
        }
       digit.GetComponent<TextMeshProUGUI>().text=PlayerEvent.Day.ToString();
       StartCoroutine(showquestagain());
       
    }
    public void show()
    {
        StartCoroutine(showquest());
    }
    public void showatfirst(string _id)
    {
        if(_id=="daychange")
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
