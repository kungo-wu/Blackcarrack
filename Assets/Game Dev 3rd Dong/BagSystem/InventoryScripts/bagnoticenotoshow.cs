using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagnoticenotoshow : MonoBehaviour
{
    public GameObject bagnotice;
    public static bool bagnoticetimetoshow;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    {

        if(bagnoticetimetoshow)// 使用字符串格式化将dayNum插入到文本中
        bagnotice.SetActive(true);
        bagnoticetimetoshow=false;
    }
    }
}
