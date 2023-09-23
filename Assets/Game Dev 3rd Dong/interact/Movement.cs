using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1.5f;    // 上下移动速度
    public float distance = 0.1f; // 上下移动距离

    private float startPosition;
    public float rotateSpeed = 1.0f;  
    public bool rotate; // 物体的旋转速度

    void Start()
    {
        startPosition = transform.position.y;
    }

    void Update()
    {
        // 计算新的位置
        float newPosition = startPosition;
        newPosition+= Mathf.Sin(Time.time * speed) * distance;
           // 让物体沿着 y 轴平均旋转
        transform.Rotate(0.0f, 360.0f * rotateSpeed * Time.deltaTime, 0.0f);
        if(!rotate)
        {
            transform.LookAt(Camera.main.transform);

        }
        
        // 移动物体
        transform.position = new Vector3(transform.position.x,newPosition,transform.position.z);
    }
}
