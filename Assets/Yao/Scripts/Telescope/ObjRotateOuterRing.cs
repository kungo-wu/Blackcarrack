using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjRotateOuterRing : MonoBehaviour
{
    private bool isPress;//�Ƿ���
    public float rotatingSpeed = 10;

    private Vector3 startPos;//��ʼλ��
    private Vector3 endPos;//����λ��

    public float dis;//����


    //�������ж���껬��������Ҫ�Ķ���
    Vector2 lastPos;//����ϴ�λ��
    Vector2 currPos;//��굱ǰλ��
    Vector2 offset;//����λ�õ�ƫ��ֵ
    private bool isRight;//����Ƿ����һ���

    //�������жϲ�ͬԲ������Ķ���
    bool innerRing=false;
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            lastPos = Input.mousePosition;
            isPress = true;

            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);//��������
            RaycastHit mHit;

            if (Physics.Raycast(mRay, out mHit))
            {

                if (mHit.collider.gameObject.tag == "Outer Ring")
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
                Vector3 offset = endPos - startPos;
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
            //ˮƽ�ƶ�
            if (Mathf.Abs(offset.x) > Mathf.Abs(offset.y))
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
            /*else//��ֱ�ƶ�
            {
                if (offset.y > 0)
                {
                    Debug.Log("��");
                }
                else
                {
                    Debug.Log("��");
                }
            }*/
        }

    }

