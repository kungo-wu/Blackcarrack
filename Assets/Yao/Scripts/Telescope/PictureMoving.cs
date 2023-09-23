using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Reflection;

public class PictureMoving : MonoBehaviour
{
    public GameObject backGround;
    public GameObject innerRing;
    public GameObject outerRing;

   
    public Vector3 invector3;
    public Vector3 outvector3;
    public Vector3 vector3;
    private float initialRotation1; // 环1的初始旋转值
    private float initialRotation2;
    public static bool innercanmove;
    public static bool outercanmove;
    // Start is called before the first frame update
    void Start()
    {
        initialRotation1 = innerRing.transform.eulerAngles.z;
        initialRotation2 = outerRing.transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        
        backGround.transform.position =ConvertRotationToMovement(innerRing.transform, outerRing.transform);
        
        /*if(innerRing.transform.eulerAngles.z>148f&&innerRing.transform.eulerAngles.z<275f)
        {
            
            //innerRing.transform.eulerAngles=new Vector3(innerRing.transform.eulerAngles.x,innerRing.transform.eulerAngles.y,148f);
            
            innercanmove=false;
        }
        else
        {
            backGround.transform.position =ConvertRotationToMovement(innerRing.transform, outerRing.transform);
              innercanmove=true;
        }
        //Debug.Log(outerRing.transform.eulerAngles.z);
       if(outerRing.transform.eulerAngles.z>164f&&outerRing.transform.eulerAngles.z<192f)
        {
            
            outerRing.transform.eulerAngles=new Vector3(outerRing.transform.eulerAngles.x,outerRing.transform.eulerAngles.y,164f);
            
            outercanmove=false;
        }if(outerRing.transform.eulerAngles.z>180f&&outerRing.transform.eulerAngles.z<192f)
        {
            
            outerRing.transform.eulerAngles=new Vector3(outerRing.transform.eulerAngles.x,outerRing.transform.eulerAngles.y,192f);
            
            outercanmove=false;
        }
        else
        {
             backGround.transform.position =ConvertRotationToMovement(innerRing.transform, outerRing.transform);
              outercanmove=true;
        }*/
        //GetInspectorRotationValueMethod(innerRing.transform,ref invector3);
        //GetInspectorRotationValueMethod(outerRing.transform, ref outvector3);
       // ConvertRotationToMovement(innerRing.transform, outerRing.transform);
       
        //backGround.transform.position = new Vector3(outvector3.z/180, invector3.z/180, -5 / 100);
        

    }
    public void GetInspectorRotationValueMethod(Transform transform,ref Vector3 _vector3)
    {
        // ��ȡԭ��ֵ
        System.Type transformType = transform.GetType();
        PropertyInfo m_propertyInfo_rotationOrder = transformType.GetProperty("rotationOrder", BindingFlags.Instance | BindingFlags.NonPublic);
        object m_OldRotationOrder = m_propertyInfo_rotationOrder.GetValue(transform, null);
        MethodInfo m_methodInfo_GetLocalEulerAngles = transformType.GetMethod("GetLocalEulerAngles", BindingFlags.Instance | BindingFlags.NonPublic);
        object value = m_methodInfo_GetLocalEulerAngles.Invoke(transform, new object[] { m_OldRotationOrder });
        string temp = value.ToString();
        //���ַ�����һ�������һ��ȥ��
        temp = temp.Remove(0, 1);
        temp = temp.Remove(temp.Length - 1, 1);
        //�á������ŷָ�
        string[] tempVector3;
        tempVector3 = temp.Split(',');
        //���ָ�õ����ݴ���Vector3
        Vector3 getvector3 = new Vector3(float.Parse(tempVector3[0]), float.Parse(tempVector3[1]), float.Parse(tempVector3[2]));
        _vector3 = getvector3;
    }
    public Vector3 RotationAndPosition()
    {
        return vector3;
    }
    public Vector3 ConvertRotationToMovement(Transform ring1, Transform ring2)
{
    // 获取环的旋转值
    float currentRotation1 = ring1.eulerAngles.z;
    float currentRotation2 = ring2.eulerAngles.z;

// 计算相对角度变化
    float rotationChange1 = Mathf.DeltaAngle(initialRotation1, currentRotation1);
    float rotationChange2 = Mathf.DeltaAngle(initialRotation2, currentRotation2);
    

// 计算移动距离和方向
    float x = rotationChange2/100-1f;
    float y = rotationChange1/100-1f;

// 应用移动距离和方向到其他物体


    // 返回移动方向作为二维向量
    return new Vector3(x, y,0);
}
}
