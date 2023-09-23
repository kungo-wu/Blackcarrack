using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class daynotice : MonoBehaviour
{
    public static bool one=true;
    public static bool three=true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(PlayerEvent.Day==1&&one&&SceneManager.GetActiveScene().name=="Deck(Ship)")
        {
            StartCoroutine(first());
           one=false;

        }
         if(PlayerEvent.Day==3&&three&&SceneManager.GetActiveScene().name=="Deck(Ship)")
        {
            StartCoroutine(third());
            three=false;

        }
    }
    private IEnumerator first()
    {
        yield return new WaitForSeconds(0.5f); // 延迟0.5秒

        // 在这里写下你想要延迟执行的函数的代码
        GameEventSystem.instance.Temporarychange("day1firstnotice");
    }
    private IEnumerator third()
    {
        yield return new WaitForSeconds(0.5f); // 延迟0.5秒

        // 在这里写下你想要延迟执行的函数的代码
        GameEventSystem.instance.Temporarychange("day3firstnotice");
    }
}
