using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RingController : MonoBehaviour
{
    public float rotateSpeed = 10f; // 旋转速度
    public float startRotateDistance = 20f; // 开始旋转的最小距离
    Vector3 lastMousePosition; // 上一帧鼠标位置
    private bool isRotate = false; // 是否开始旋转
    private bool inner= false;
    private bool outer= false;
    private float rotateAngle = 0f; // 旋转角度
    
void Start()
{
    StartCoroutine(first());
}
 private IEnumerator first()
    {
        yield return new WaitForSeconds(0.5f); // 延迟0.5秒

        // 在这里写下你想要延迟执行的函数的代码
        GameEventSystem.instance.Temporarychange("telescope");
    }
    void Update()
{
    
    
    // 鼠标按下第一帧时，记录鼠标位置用于下帧计算
    if (Input.GetMouseButtonDown(0))
    {
        Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mHit;

        if (Physics.Raycast(mRay, out mHit))
        {
            if (mHit.collider.gameObject.tag == "Inner Ring")
            {
                Debug.Log("内圈");
                isRotate = true;
                inner=true;
            }
            if (mHit.collider.gameObject.tag == "Outer Ring")
            {
                 Debug.Log("外圈");
                isRotate = true;
                outer=true;
            }
            lastMousePosition = Input.mousePosition;
        }
    }

    // 鼠标按下并且鼠标拖动距离大于 startRotateDistance，开始旋转
    if (isRotate &&inner&& gameObject.CompareTag("Inner Ring")&&Input.GetMouseButton(0) && Vector3.Distance(lastMousePosition, Input.mousePosition) > startRotateDistance)
    {
        
        // 判断鼠标移动的方向，用于旋转的正反方向
        float cross = Vector3.Cross(lastMousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0f), Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0f)).z;
        bool isClockwise = cross < 0;

        // 根据旋转方向每帧旋转对应角度
        if (isClockwise)
        {
            rotateAngle += rotateSpeed * Time.deltaTime;
        }
        else
        {
            rotateAngle -= rotateSpeed * Time.deltaTime;
        }
        if(rotateAngle<=0f)
        {
            rotateAngle=0f;
        }
        if(rotateAngle>=359f)
        {
            rotateAngle=359f;
        }
        if(rotateAngle<180f)
        {
            // 更新旋转角度
        transform.rotation = Quaternion.Euler(0, 0, rotateAngle);

        }
        else
        {
            lastMousePosition = Input.mousePosition;
        }

        

        // 记录此次鼠标位置
        lastMousePosition = Input.mousePosition;
    }
    if (isRotate &&outer&&gameObject.CompareTag("Outer Ring")&& Input.GetMouseButton(0) && Vector3.Distance(lastMousePosition, Input.mousePosition) > startRotateDistance)
    {
        // 判断鼠标移动的方向，用于旋转的正反方向
        float cross = Vector3.Cross(lastMousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0f), Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0f)).z;
        bool isClockwise = cross < 0;

        // 根据旋转方向每帧旋转对应角度
        if (isClockwise)
        {
            rotateAngle += rotateSpeed * Time.deltaTime;
        }
        else
        {
            rotateAngle -= rotateSpeed * Time.deltaTime;
        }

        if(rotateAngle<=0f)
        {
            rotateAngle=0f;
        }
        if(rotateAngle>=359f)
        {
            rotateAngle=359f;
        }
        if(rotateAngle<180f)
        {
            // 更新旋转角度
        transform.rotation = Quaternion.Euler(0, 0, rotateAngle);

        }
        else
        {
            lastMousePosition = Input.mousePosition;
        }
        
        // 记录此次鼠标位置
        lastMousePosition = Input.mousePosition;
    }


    // 鼠标释放后停止旋转
    if (Input.GetMouseButtonUp(0))
    {
        isRotate = false;
        inner=false;
        outer=false;
    }
}



}
