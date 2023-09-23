using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemuianimation : MonoBehaviour
{
    public AnimationCurve showcurve;
    public AnimationCurve hidecurve;
    public float animationspeed;
    private Vector3 scale;
    //public GameObject quest;
    // Start is called before the first frame update
    void Awake()
    {
        scale=gameObject.transform.localScale;
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
            gameObject.transform.localScale=scale*showcurve.Evaluate(timer);
            timer+=Time.deltaTime*animationspeed;
            yield return null;
        }
    }
    public IEnumerator hidequest()
    {
        float timer=0;
        while(timer<=1)
        {
            gameObject.transform.localScale=scale*hidecurve.Evaluate(timer);
            timer+=Time.deltaTime*animationspeed;
            yield return null;
        }
    }
    public IEnumerator destroyquest()
    {
        float timer=0;
        while(timer<=1)
        {
            gameObject.transform.localScale=scale*hidecurve.Evaluate(timer);
            timer+=Time.deltaTime*animationspeed;
            yield return null;
        }
        Destroy(transform.parent.gameObject);
    }
    public void show()
    {
        StartCoroutine(showquest());
    }
    public void hide()
    {
        StartCoroutine(hidequest());
    }
    public void destroy()
    {
        StartCoroutine(destroyquest());
    }
}