using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 版本Unity2017.1.0f3
/// </summary>

public class GameManage : MonoBehaviour
{

    public GameObject[] mycylinders;//所有圆柱

    public GameObject[] mytorus;//所有圆环
    public GameObject Temp;//临时存储

    public Text scoreText;
    private int step;
    void Start()
    {
        //Debug.Log(mycylinders[0]);
      //  for (int i = 0; i < mytorus.Length; i++)//让所有圆环先加入第一个圆柱中
       // {
       //     Debug.LogWarning("第" + i + "个圆环被插入圆柱A");
       //     mycylinders[0].GetComponent<Cylinder>().Torus_List.Add(mytorus[i]);
      //  }
    }

    public void AddScore()
    {
        step++;
        scoreText.text = "移动步数：" + step;
    }
}

