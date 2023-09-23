using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public float duration;
    private float _timer;
    public static bool Sceneleaving;
    public static bool Scenecoming;

   
    // Start is called before the first frame update
    CanvasGroup canvasGroup;
    void Start()
    {
        
        canvasGroup = GetComponent<CanvasGroup>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Sceneleaving==false)
        {
            canvasGroup.alpha=0;
        }
        if (_timer<duration&&Scenecoming==true)
        {
            _timer += Time.deltaTime;
            canvasGroup.alpha = 1 - _timer / duration;
        }
        if(canvasGroup.alpha ==0)
        {
            Scenecoming=false;
             _timer =0;
        }
    }
}
