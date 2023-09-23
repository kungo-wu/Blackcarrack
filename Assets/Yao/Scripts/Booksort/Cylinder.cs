using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 版本Unity2017.1.0f3
/// </summary>

public class Cylinder : MonoBehaviour
{
    [SerializeField]
    private int _index;//本柱序号

    public List<GameObject> Torus_List = new List<GameObject>();//存储本柱圆环

    [SerializeField]
    private GameObject _Temp;
    private bool _isTrans;//可以最上面可以移动

    [SerializeField]
    private GameManage GameManager;

    public int Index
    {
        get { return _index; }
    }

    void OnMouseDown()
    {
        _isTrans = _Temp.GetComponent<Temp>().isNull;
        if (_isTrans == true)//可以移动
        {
            if (Torus_List.Count != 0)//判断柱子上是否有圆环
            {
                TakeTorus();
            }
            else if (Torus_List.Count == 0)//判断柱子上没有东西
            {
                Debug.Log("你点击的这个柱子没有东西！");
            }
        }
        if (_isTrans == false)
        {
            if (Torus_List.Count == 0)//判断要放置的柱子是否有物体
            {
                TranslateFunc();
            }
            if (Torus_List.Count != 0)//判断要放置的柱子有圆环
            {
                if (_Temp.GetComponent<Temp>().Torus_Obj != null)
                {
                    int a_length = _Temp.GetComponent<Temp>().Torus_Obj.GetComponent<Torus>().TLength;//暂存的圆环长度
                    int b_length = Torus_List[Torus_List.Count - 1].GetComponent<Torus>().TLength;
                    if (a_length < b_length)
                    {
                        TranslateFunc();
                        if (Torus_List.Count == GameManager.mytorus.Length && this._index == 3)
                        {
                            Debug.LogWarning("胜利！！！");
                        }
                    }
                    else
                    {
                        Debug.Log("放置错误，请重新放置！！！");
                    }
                }
            }
        }

    }

    void TranslateFunc()
    {
        Torus_List.Add(_Temp.GetComponent<Temp>().Torus_Obj);//为泛型列表添加_Temp暂存得东西
        Torus_List[Torus_List.Count - 1].transform.position = new Vector3(transform.position.x, transform.position.y  + (Torus_List.Count - 1), transform.position.z);//让移动的圆环移动过去
        _Temp.GetComponent<Temp>().Torus_Obj = null;//清空暂存
        _Temp.GetComponent<Temp>().isNull = true;//可以再次移动，_Temp是空的
        Debug.Log("已经移动到" + gameObject.name);
        GameManager.AddScore();//步数增加
    }

    void TakeTorus()
    {
        //Debug.Log("圆柱被点击！");
        //Debug.Log(Torus_List[Torus_List.Count - 1] + "为最上面的！");
        Torus_List[Torus_List.Count - 1].transform.position = _Temp.transform.position;//移动位置
        _Temp.GetComponent<Temp>().Torus_Obj = Torus_List[Torus_List.Count - 1];//Temp暂存圆环
        _Temp.GetComponent<Temp>().isNull = false;//Temp处已经有东西了
        Torus_List.RemoveAt(Torus_List.Count - 1);//移除在在最上面的圆环
                                                  //Debug.Log(_isTrans);
    }
}
