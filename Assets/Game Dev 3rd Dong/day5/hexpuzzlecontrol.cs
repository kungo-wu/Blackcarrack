using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hexpuzzlecontrol : MonoBehaviour
{
    public GameObject[] points;
    public static GameObject nowpoint;
    public static int  index=1;
    private Transform origintransform;
    public static bool choose;
    private static bool one=true;
    public static bool process;
    // Start is called before the first frame update
    void Start()
    {
        origintransform=gameObject.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
         //Debug.Log(index);
         if(!choose)
         {
            gameObject.transform.SetParent(origintransform);
            if(nowpoint!=null)
            {
                 if(nowpoint.transform.childCount==0)
            {
                nowpoint.SetActive(false);
                index=1;
                process=false;

            }

            }
           
           
         }
    }
    private void OnTriggerStay(Collider other) 
    {
        
        if(other.CompareTag("hexpuzzle"))
        {
           
            gameObject.transform.SetParent(other.transform,true);
        }
        
    }
    private GameObject GetClosestPoint()
    {
        GameObject closestPoint = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject point in points)
        {
            float distance = Vector3.Distance(transform.position, point.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPoint = point;
            }
        }

        return closestPoint;
    }
    private void OnMouseDown() 
    {
        
        if(Input.GetMouseButton(0))
        {
            if(index==1&&!process)
            {
               one=true;
               choose=true;
               process=true;
               nowpoint=GetClosestPoint();
               nowpoint.SetActive(true);
               StartCoroutine(SmoothMove(nowpoint,0.005f));
               index++;
               return;
            }
            if(index==2&&!process)
            {
                process=true;
                StartCoroutine(SmoothRotate(nowpoint));
                index++;
                return;
            }
           
        }
        
    }
    private void OnMouseOver() 
{
    
    if(Input.GetMouseButton(1)&&index==2&&one&&!process)
    {
        StartCoroutine(SmoothMoveback(nowpoint,-0.005f));
        process=true;
        //nowpoint.SetActive(false);
        one=false;

        //utilitycontrol.rightclick(index);
    }
}
    private IEnumerator  SmoothMove(GameObject _gameobject,float _distance)
    {
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / 1f);  // 计算归一化时间 (0-1范围)

            // 使用差值函数 (Lerp) 平滑地移动物体的 X 轴位置
            _gameobject.transform.position = Vector3.Lerp(_gameobject.transform.position,_gameobject.transform.position+new Vector3(_distance,0,0), t);

            // 等待一帧
            yield return null;
        }
        process=false;
    }
    private IEnumerator  SmoothMoveback(GameObject _gameobject,float _distance)
    {
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / 1f);  // 计算归一化时间 (0-1范围)

            // 使用差值函数 (Lerp) 平滑地移动物体的 X 轴位置
            _gameobject.transform.position = Vector3.Lerp(_gameobject.transform.position,_gameobject.transform.position+new Vector3(_distance,0,0), t);

            // 等待一帧
            yield return null;
        }
        choose=false;
       
    }
    private IEnumerator SmoothRotate(GameObject _gameobject)
    {
        float elapsedTime = 0f;
        Quaternion startRotation = _gameobject.transform.rotation;
        Quaternion targetRotation = startRotation * Quaternion.AngleAxis(120f, Vector3.right);
        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / 1f);  // 计算归一化时间 (0-1范围)

            // 使用Slerp函数以匀速旋转物体
           _gameobject.transform.rotation = Quaternion.Slerp(_gameobject.transform.rotation, targetRotation, t);

            yield return null;
        }
       
        // 确保最终旋转角度准确
        index--;
        process=false;
    }
}
