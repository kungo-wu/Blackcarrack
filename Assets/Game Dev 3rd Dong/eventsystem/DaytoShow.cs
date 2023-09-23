using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DaytoShow : MonoBehaviour
{
    public static bool daytoshowtimetoshow;
    public TextMeshProUGUI dayShowText;
    public GameObject back;
    void Update()
    {

        if(daytoshowtimetoshow)// 使用字符串格式化将dayNum插入到文本中
        {
            back.SetActive(true);
            dayShowText.text = string.Format("第{0}天", PlayerEvent.Day);

        }
        
    }

}
