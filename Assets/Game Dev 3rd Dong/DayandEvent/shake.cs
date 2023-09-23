using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/// <summary>
/// boss攻击玩家产生的震动方法
/// 挂载到主摄像机上
/// </summary>
public class shake : MonoBehaviour 
{
    public static shake instance;
    public static GameObject cm1;
    public float cameraShake = 2;//震动系数
    //public GameObject UI;//红色的背景图片
 
	void Start()
    {
        cm1=GameObject.Find("CM vcam1");
    }
    void Update () 
    {
        
    }
    public   void shakescreen()
    {
        
            
            //X,Y轴震动
            cm1.transform.position = new Vector3((Random.Range(0f, instance.cameraShake)) -  cameraShake*0.5f, cm1.transform.position.y,cm1. transform.position.z);
            //Z轴震动
            cm1.transform.position = new Vector3(cm1.transform.position.x, cm1.transform.position.y, (Random.Range(0f, cameraShake)) - cameraShake * 0.5f);
            instance.cameraShake =instance. cameraShake / 1.05f;
            if (cameraShake<0.05f)
            {
 
                cameraShake= 0;
                //UI.SetActive(false);
               // Gun.Instance.bossAttack = false;
            }
        
        else
        {
            cameraShake = 5;
        }

    }
}