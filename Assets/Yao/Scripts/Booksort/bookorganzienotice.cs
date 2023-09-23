using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookorganzienotice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(first());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator first()
    {
        yield return new WaitForSeconds(0.5f); // 延迟0.5秒

        // 在这里写下你想要延迟执行的函数的代码
        GameEventSystem.instance.Temporarychange("bookorganize");
        //corouting=false;
    }
}
