using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchenshowfish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEventSystem.instance.onTemporarychange+=showfish;
    }
    void OnDisable()
    {
        GameEventSystem.instance.onTemporarychange-=showfish;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showfish(string _id)
    {
        if(_id==""+0)
        {
            transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }
        if(_id==""+1)
        {
            transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        }
        if(_id==""+2)
        {
            transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
        }
        if(_id==""+3)
        {
            transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
        }
        if(_id==""+4)
        {
            transform.GetChild(4).GetChild(0).gameObject.SetActive(true);
        }
    }
}
