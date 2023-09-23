using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �汾Unity2017.1.0f3
/// </summary>

public class Cylinder : MonoBehaviour
{
    [SerializeField]
    private int _index;//�������

    public List<GameObject> Torus_List = new List<GameObject>();//�洢����Բ��

    [SerializeField]
    private GameObject _Temp;
    private bool _isTrans;//��������������ƶ�

    [SerializeField]
    private GameManage GameManager;

    public int Index
    {
        get { return _index; }
    }

    void OnMouseDown()
    {
        _isTrans = _Temp.GetComponent<Temp>().isNull;
        if (_isTrans == true)//�����ƶ�
        {
            if (Torus_List.Count != 0)//�ж��������Ƿ���Բ��
            {
                TakeTorus();
            }
            else if (Torus_List.Count == 0)//�ж�������û�ж���
            {
                Debug.Log("�������������û�ж�����");
            }
        }
        if (_isTrans == false)
        {
            if (Torus_List.Count == 0)//�ж�Ҫ���õ������Ƿ�������
            {
                TranslateFunc();
            }
            if (Torus_List.Count != 0)//�ж�Ҫ���õ�������Բ��
            {
                if (_Temp.GetComponent<Temp>().Torus_Obj != null)
                {
                    int a_length = _Temp.GetComponent<Temp>().Torus_Obj.GetComponent<Torus>().TLength;//�ݴ��Բ������
                    int b_length = Torus_List[Torus_List.Count - 1].GetComponent<Torus>().TLength;
                    if (a_length < b_length)
                    {
                        TranslateFunc();
                        if (Torus_List.Count == GameManager.mytorus.Length && this._index == 3)
                        {
                            Debug.LogWarning("ʤ��������");
                        }
                    }
                    else
                    {
                        Debug.Log("���ô��������·��ã�����");
                    }
                }
            }
        }

    }

    void TranslateFunc()
    {
        Torus_List.Add(_Temp.GetComponent<Temp>().Torus_Obj);//Ϊ�����б����_Temp�ݴ�ö���
        Torus_List[Torus_List.Count - 1].transform.position = new Vector3(transform.position.x, transform.position.y  + (Torus_List.Count - 1), transform.position.z);//���ƶ���Բ���ƶ���ȥ
        _Temp.GetComponent<Temp>().Torus_Obj = null;//����ݴ�
        _Temp.GetComponent<Temp>().isNull = true;//�����ٴ��ƶ���_Temp�ǿյ�
        Debug.Log("�Ѿ��ƶ���" + gameObject.name);
        GameManager.AddScore();//��������
    }

    void TakeTorus()
    {
        //Debug.Log("Բ���������");
        //Debug.Log(Torus_List[Torus_List.Count - 1] + "Ϊ������ģ�");
        Torus_List[Torus_List.Count - 1].transform.position = _Temp.transform.position;//�ƶ�λ��
        _Temp.GetComponent<Temp>().Torus_Obj = Torus_List[Torus_List.Count - 1];//Temp�ݴ�Բ��
        _Temp.GetComponent<Temp>().isNull = false;//Temp���Ѿ��ж�����
        Torus_List.RemoveAt(Torus_List.Count - 1);//�Ƴ������������Բ��
                                                  //Debug.Log(_isTrans);
    }
}
