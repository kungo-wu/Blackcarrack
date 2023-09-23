using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class processcontrol : MonoBehaviour
{
    public Image image;
    
    public static bool qteok=false;
    
    public Text keyText;  
    public KeyCode currentKey;
    public GameObject cm1;
    public float cameraShake = 2f;//震动系数
    
    // Start is called before the first frame update
    void Start()
    {
        cm1=GameObject.Find("VCam Pivot");
        if(qtetrigger.qtetodoclick==true)
        {
           image.fillAmount=1;
        }
        if(qtetrigger.qtetodoclickmore==true)
            {
                image.fillAmount=0;
            }
    }

    // Update is called once per frame
    void Update()
    {
       processclick();
       processclickmore();
    }
    public void processclick()
    {
       
        if(qtetrigger.qtetodoclick==true)
        {
            
        
        if(image.fillAmount>0)
        {
            image.fillAmount-=qtetrigger.speed*Time.deltaTime;
            
            if(Input.GetKeyDown(currentKey))
        {
            print("sucess");
    
               
                GameEventSystem.instance.QTEfinished();
                Destroy(gameObject);
                qteok=false;
        
            
         
        }
        
        }
       
        }
    }
     public void processclickmore()
    {
        
        if(qtetrigger.qtetodoclickmore==true)
        {
            //print("clickmore");
             if(image.fillAmount<1 )
        {
        
            if(Input.GetKeyDown(currentKey))
        {
            StartCoroutine(Shake(.25f, .5f));
            print("sucess");
            image.fillAmount+= qtetrigger.raise;
            if( image.fillAmount>=1)
            {
                GameObject.Find("Player").GetComponent<Animator>().ResetTrigger("Captured");
                GameEventSystem.instance.QTEfinished();
                Destroy(gameObject);
                qteok=false;
            }
            
         
        }
        }
            if(image.fillAmount>=0&&image.fillAmount<1)
        {
            image.fillAmount-=qtetrigger.speed*Time.deltaTime;
        }
         
        }
    }
    
    public void SetKey(KeyCode key)
{
    keyText.text = key.ToString(); // 将按键的名称显示在 Text 组件中
    currentKey = key;              // 将当前按键保存到 currentKey 变量中
}
public IEnumerator Shake(float duration,float magnitude)//摇晃时间、幅度
    {
        Vector3 originalPos = cm1.transform.localPosition;//相机原始位置
 
        float elapsed = 0.0f;//摇晃进行时间
        while (elapsed < duration)
        {
            float x = Random.Range(-2f, 2f) * magnitude;//x轴随机抖动幅度
            float y = Random.Range(-2f, 2f) * magnitude;//y轴随机抖动幅度
 
           cm1. transform.localPosition = new Vector3(x, y, originalPos.z);
 
            elapsed += Time.deltaTime;
 
            yield return null;
        }
        cm1.transform.localPosition = originalPos;//再次复原
    }

}
