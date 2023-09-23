using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjRotateInnerRing : MonoBehaviour
{
    private bool isPress;//是否按下
    public float rotatingSpeed = 10;

    private Vector3 startPos;//开始位置
    private Vector3 endPos;//结束位置

    public float dis;//距离


    //以下是判定鼠标滑动方向需要的定义
    Vector2 lastPos;//鼠标上次位置
    Vector2 currPos;//鼠标当前位置
    Vector2 offset;//两次位置的偏移值
    private bool isRight;//鼠标是否向右滑动

    //以下是判断不同圆环所需的定义
    bool innerRing=false;
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            lastPos = Input.mousePosition;
            isPress = true;

            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);//发射射线
            RaycastHit mHit;

            if (Physics.Raycast(mRay, out mHit))
            {

                if (mHit.collider.gameObject.tag == "Inner Ring")
                {
                    innerRing = true;
                }
                else
                {
                    innerRing = false;

                }


            }
        }
        if (Input.GetMouseButtonUp(0))
            {
                currPos = Input.mousePosition;
                offset = currPos - lastPos;
                DoMatch(offset);
            isPress = false;
            innerRing = false;
        }


          

            startPos = Input.mousePosition;
            if (isPress&&innerRing)
            {
                Vector2 offset = currPos - lastPos;
                if (isRight)
                {
                    transform.Rotate(Vector3.back * Time.deltaTime * offset.sqrMagnitude * rotatingSpeed);

                }
                else
                {
                    transform.Rotate(Vector3.back * Time.deltaTime * offset.sqrMagnitude * -rotatingSpeed);
                }

            }
            endPos = Input.mousePosition;

        }

        void DoMatch(Vector2 _offset)
        {
            //水平移动
            
            {
                if (offset.x > 0)
                {
                    isRight = true;
                }
                else
                {
                    isRight = false;
                }
            }
            /*else//垂直移动
            {
                if (offset.y > 0)
                {
                    Debug.Log("上");
                }
                else
                {
                    Debug.Log("下");
                }
            }*/
        }

    }

