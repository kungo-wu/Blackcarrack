using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �汾Unity2017.1.0f3
/// </summary>

public class GameManage : MonoBehaviour
{

    public GameObject[] mycylinders;//����Բ��

    public GameObject[] mytorus;//����Բ��
    public GameObject Temp;//��ʱ�洢

    public Text scoreText;
    private int step;
    void Start()
    {
        //Debug.Log(mycylinders[0]);
      //  for (int i = 0; i < mytorus.Length; i++)//������Բ���ȼ����һ��Բ����
       // {
       //     Debug.LogWarning("��" + i + "��Բ��������Բ��A");
       //     mycylinders[0].GetComponent<Cylinder>().Torus_List.Add(mytorus[i]);
      //  }
    }

    public void AddScore()
    {
        step++;
        scoreText.text = "�ƶ�������" + step;
    }
}

