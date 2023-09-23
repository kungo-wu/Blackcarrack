using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class cinemechine : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public GameObject needtofollow;
    public string gameObjectname;
    // Start is called before the first frame update
    void Start()
    {
        
        needtofollow=GameObject.Find(gameObjectname);
        virtualCamera.Follow=needtofollow.transform;
        virtualCamera.LookAt=needtofollow.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
